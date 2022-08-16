using ReferralApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReferralApp.DTOs
{
	[Serializable]
	public class InboundDataDTO 
	{
		public string next_page { get; set; }

		public List<InboundReferralDTO> referrals { get; set; }


	}
}
