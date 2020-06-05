using System;
using System.Collections.Generic;

namespace BeeKid.API.Models
{
    public partial class TbHandBook
    {
        public int HbId { get; set; }
        public string AdminuserId { get; set; }
        public DateTime? HbDatetime { get; set; }
        public string HbTitle { get; set; }
        public string HbDescription { get; set; }
    }
}
