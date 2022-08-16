using ReferralApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReferralApp.DTOs
{
	[Serializable]
	public class InboundReferralDTO : ReferralBaseDTO
	{
		public string status { get; set; }

		public string date_updated { get; set; }

		public string date_created { get; set; }

		public bool sent { get; set; }

		public string id { get; set; }

		public bool needs_follow_up { get; set; }


		public Referral ConvertToReferral()
		{
			Referral referral = new Referral();
			referral.ContactPreferences = contact_preferences;
			referral.Status = status;
			referral.DateUpdated = DateTime.Parse(date_updated).ToString("G");
			referral.DateCreated = DateTime.Parse(date_created).ToString("G");
			referral.Sent = sent ? "Yes" : "No";
			referral.ExistingReferralId = id;
			referral.NeedsFollowUp = needs_follow_up ? "Yes" : "No";
			referral.Email = receiver?.email;
			referral.DateofBirth = receiver?.date_of_birth;
			referral.ReceiverId = receiver?.id;
			referral.FirstName = receiver?.first_name;
			referral.LastName = receiver?.last_name;
			referral.PhoneNumber = receiver?.phone_number;
			referral.PreferredLanguage = receiver?.preferred_language;
			referral.Program = new ReferralProgram() { Id = program?.id, Name = program?.name, ProviderName = program?.provider_name };
			referral.Status = status;
			referral.ZipCode = receiver?.zip;

			return referral;
		}
	}
}
