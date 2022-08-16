using ReferralApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReferralApp.DTOs
{
	[Serializable]
	public class InboundResponseDTO 
	{
		public bool success { get; set; }

		public InboundDataDTO data { get; set; }


	}
}
