using System;
using System.Collections.Generic;

namespace BeeKid.API.Models
{
    public partial class TbEvent
    {
        public int EventId { get; set; }
        public DateTime? EventDatetime { get; set; }
        public string EventName { get; set; }
        public string EventImage { get; set; }
        public string EventDescription { get; set; }
        public string AdminuserId { get; set; }
        public string EventContent { get; set; }
        public string EventTagname { get; set; }
        public string EventLink { get; set; }
    }
}
