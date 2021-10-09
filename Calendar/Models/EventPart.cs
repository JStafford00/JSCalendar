using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Models
{
    /// <summary>
    /// Author: Jordan Stafford
    /// File: EventPart.cs
    /// Purpose: EventPart module for Events.
    /// </summary>
    public class EventPart : ContentPart
    {
        public string Event
        {
            get;
            set;
        }

        public string Date
        {
            get;
            set;
        }

        public string startTime
        {
            get;
            set;
        }

        public string endTime
        {
            get;
            set;
        }
    }
}
