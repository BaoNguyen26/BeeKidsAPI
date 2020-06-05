using System;
using System.Collections.Generic;

namespace BeeKid.API.Models
{
    public partial class TbSlide
    {
        public int SlideId { get; set; }
        public string SlideTitle { get; set; }
        public string SlideSubtitle { get; set; }
        public string SlideDescription { get; set; }
        public string SlideImage { get; set; }
    }
}
