using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ReferralApp.Models
{
    public class Blob
    {
        [Key]
        public string ReferralId { get; set; }

        [DisplayName("Date Updated")]
        public string Time { get; set; }

        public string Uri { get; set; }
    }
}
