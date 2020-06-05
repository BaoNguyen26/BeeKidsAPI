using System;
using System.Collections.Generic;

namespace BeeKid.API.Models
{
    public partial class TbSignUp
    {
        public int SignupId { get; set; }
        public string SignupName { get; set; }
        public string SignupEmail { get; set; }
        public int? CenterId { get; set; }
        public string SignupPhonenb { get; set; }
    }
}
