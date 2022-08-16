using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReferralApp.DTOs
{
	[Serializable]
	public class OutboundReferralDTO : ReferralBaseDTO
	{
		public string requestType { get; set; }

		public string existingReferralId { get; set; }

		public string programToReferToKey { get; set; }

		public string newStatus { get; set; }
	}
}
