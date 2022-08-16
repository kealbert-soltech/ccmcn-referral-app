using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReferralApp.DTOs
{
	[Serializable]
	public class ReferralBaseDTO
	{

		public ReceiverDTO receiver { get; set; }

		public ReferralProgramDTO program { get; set; }

		public List<string> contact_preferences { get; set; }

	}
}
