using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReferralApp.DTOs
{
    public class ReferralBlob
    {
        public string id { get; set; }
        public DateTime event_time { get; set; }
        public string resource_uri { get; set; }
    }

    public class ReferralCreated
    {
        public ReferralBlob referral { get; set; }
    }

    public class ReferralBlobDTO
    {
        [JsonProperty("referral-created")]
        public ReferralCreated ReferralCreated { get; set; }
    }
}
