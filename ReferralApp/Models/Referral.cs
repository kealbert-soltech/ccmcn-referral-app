using Microsoft.AspNetCore.Mvc.Rendering;
using ReferralApp.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReferralApp.Models
{
	public class Referral
	{
		public string RequestType { get; set; }

		[Key]
		public string ExistingReferralId { get; set; }

		public string Status { get; set; }

		public string Sent { get; set; }

		[DisplayName("Needs Follow Up")]
		public string NeedsFollowUp { get; set; }

		[DisplayName("Date Updated")]
		public string DateUpdated { get; set; }

		[DisplayName("Date Created")]
		public string DateCreated { get; set; }

		public string ReceiverId { get; set; }

		[DisplayName("First Name")]
		public string FirstName { get; set; }

		[DisplayName("Last Name")]
		public string LastName { get; set; }

		[DisplayName("Date of Birth")]
		public string DateofBirth { get; set; }

		[DisplayName("Email")]
		public string Email { get; set; }

		[DisplayName("Phone Number")]
		public string PhoneNumber { get; set; }

		[DisplayName("Zipcode")]
		public string ZipCode { get; set; }

		[DisplayName("Preferred Language")]
		public string PreferredLanguage { get; set; }

		public string Needs { get; set; }

		public ReferralProgram Program { get; set; }

		public List<SelectListItem> AvailablePrograms { get; set; }

		public List<string> ContactPreferences { get; set; }

		public List<string> AvailableContactPreferences { get; set; }

		public OutboundReferralDTO ConvertToOutboundReferral()
		{
			OutboundReferralDTO outboundReferralDTO = new OutboundReferralDTO();
			outboundReferralDTO.contact_preferences = ContactPreferences == null ? new List<string>() : ContactPreferences.Select(c => c.ToLower()).ToList();
			outboundReferralDTO.existingReferralId = ExistingReferralId == null ? "" : ExistingReferralId;
			outboundReferralDTO.newStatus = Status == null ? "" : Status;
			outboundReferralDTO.programToReferToKey = Program?.Id == null ? "" : Program?.Id;
			outboundReferralDTO.program = new ReferralProgramDTO() 
			{ 
				id = Program?.Id == null ? "" : Program?.Id, 
				name = Program?.Name == null ? "" : Program?.Name, 
				provider_name = Program?.ProviderName == null ? "" : Program?.ProviderName
			};
			outboundReferralDTO.receiver = new ReceiverDTO()
			{
				date_of_birth = DateofBirth == null ? "" : DateofBirth,
				email = Email == null ? "" : Email,
				first_name = FirstName == null ? "" : FirstName,
				id = ReceiverId == null ? "" : ReceiverId,
				last_name = LastName == null ? "" : LastName,
				phone_number = PhoneNumber == null ? "" : PhoneNumber,
				preferred_language = PreferredLanguage == null ? "" : PreferredLanguage,
				zip = ZipCode == null ? "" : ZipCode,
				needs = Needs == null ? new List<string>() : Needs.Split(",").ToList(),
				seeker_key = ""
			};
			outboundReferralDTO.requestType = RequestType;

			return outboundReferralDTO;
		}

	}
}
