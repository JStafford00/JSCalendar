using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar.Models;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using YesSql;

namespace Calendar.Controllers
{
    /// <summary>
    /// Author: Jordan Stafford
    /// File: HomeController.cs
    /// Purpose: Controller for home page.
    /// </summary>
    [Route("Calendar")]
    public class HomeController : Controller
    {
        private readonly ISession _session;
        private readonly IContentManager _contentManager;
        public List<EventPart> Events = new List<EventPart>();

        public IActionResult Index()
        {
            
            GetEvents();
            ViewData["events"] = Events.ToArray();
            return View();
        }

        public HomeController(ISession session, IContentManager contentManager)
        {
            _session = session;
            _contentManager = contentManager;
        }

        private async void GetEvents()
        {

            var eventPages = await _session
                .Query<ContentItem, ContentItemIndex>(index => index.ContentType == "Event")
                .ListAsync();

            foreach(var eventPage in eventPages)
            {

                await _contentManager.LoadAsync(eventPage);
                EventPart e = new EventPart();
                e.Event = eventPage.DisplayText;
                e.Date = eventPage.Content["Event"]["Date"]["Value"];
                e.startTime = eventPage.Content["Event"]["StartTime"]["Value"];
                e.endTime = eventPage.Content["Event"]["EndTime"]["Value"];
                Events.Add(e);
            }

            
        }
    }
}
