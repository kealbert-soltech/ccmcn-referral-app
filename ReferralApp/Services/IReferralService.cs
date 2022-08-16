using Microsoft.AspNetCore.Mvc.Rendering;
using ReferralApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReferralApp.Services
{
	public interface IReferralService
	{
		List<Referral> GetReferrals();

		void CreateReferral(Referral referral);

		void UpdateReferral(Referral referral);

		List<SelectListItem> GetPrograms(Referral referral);
	}
}
