using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReferralApp.DTOs
{
	[Serializable]
	public class ReferralProgramDTO
	{
		public string provider_name { get; set; }

		public string id { get; set; }

		public string name { get; set; }
	}
}
