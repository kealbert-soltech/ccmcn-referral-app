using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReferralApp.DTOs
{
	[Serializable]
	public class ReceiverDTO
	{

		public string first_name { get; set; }

		public string last_name { get; set; }

		public string date_of_birth { get; set; }

		public string id { get; set; }

		public string email { get; set; }

		public string phone_number { get; set; }

		public string zip { get; set; }

		public string preferred_language { get; set; }

		public string seeker_key { get; set; }

		public List<string> needs { get; set; }
	}
}
