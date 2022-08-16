using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReferralApp.Models
{
	public class ContactPreference
	{
		[Key]
		public string Preference { get; set; }
	}
}
