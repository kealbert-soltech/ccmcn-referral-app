using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReferralApp.Models
{
	public class ReferralProgram
	{
		[DisplayName("Provider Name")]
		public string ProviderName { get; set; }

		[Key]
		public string Id { get; set; }

		[DisplayName("Name")]
		public string Name { get; set; }
	}
}
