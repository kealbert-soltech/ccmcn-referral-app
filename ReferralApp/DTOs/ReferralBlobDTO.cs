using Newtonsoft.Json;
using ReferralApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReferralApp.DTOs
{
    public class ReferralBlob
    {
        public string id { get; set; }
        public string event_time { get; set; }
        public string resource_uri { get; set; }

        public Blob ConvertToBlob()
        {
            Blob blob = new Blob();

            blob.ReferralId = id;
            blob.Time = DateTime.Parse(event_time).ToString("G");
            blob.Uri = resource_uri;

            return blob;
        }
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
