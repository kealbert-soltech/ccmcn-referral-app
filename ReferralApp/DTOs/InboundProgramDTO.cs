using ReferralApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReferralApp.DTOs
{
	[Serializable]
	public class InboundProgramDTO 
	{

		public List<ReferralProgramDTO> programs { get; set; }


	}
}
