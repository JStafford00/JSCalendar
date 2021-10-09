using Calendar.Models;
using OrchardCore.ContentManagement.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Handler
{
    public class EventPartHandler : ContentPartHandler<EventPart>
    {
        public override Task UpdatedAsync(UpdateContentContext context, EventPart instance)
        {
            context.ContentItem.DisplayText = instance.Event;
            return Task.CompletedTask;
        }
    }
}
