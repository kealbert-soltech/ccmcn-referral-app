using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReferralApp.Models
{
	public class Receiver
	{
		[DisplayName("First Name")]
		public string FirstName { get; set; }

		[DisplayName("Last Name")]
		public string LastName { get; set; }

		[DisplayName("Date of Birth")]
		public string DateofBirth { get; set; }

		[Key]
		[DisplayName("Email")]
		public string Email { get; set; }

		[DisplayName("Phone Number")]
		public string PhoneNumber { get; set; }

		[DisplayName("Zipcode")]
		public string ZipCode { get; set; }

		[DisplayName("Preferred Language")]
		public string PreferredLanguage { get; set; }
	}
}
