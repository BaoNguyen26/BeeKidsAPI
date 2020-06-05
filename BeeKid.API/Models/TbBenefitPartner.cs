using System;
using System.Collections.Generic;

namespace BeeKid.API.Models
{
    public partial class TbBenefitPartner
    {
        public int BpId { get; set; }
        public string BpTitle { get; set; }
        public string BpTab { get; set; }
        public string BpDescription { get; set; }
        public string BpSubDescription { get; set; }
        public string BpCheck { get; set; }
        public string BpImg { get; set; }
    }
}
