using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ReferralApp.DTOs;
using ReferralApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ReferralApp.Services
{
	public class ReferralService : IReferralService
	{
		private const string ReferralsForProgramRequestType = "referralsForProgram";
		private const string CreateReferralRequestType = "createReferral";
		private const string UpdateReferralStatusRequestType = "updateReferralStatus";
		private const string SearchProgramsRequestType = "searchPrograms";


		public List<Referral> GetReferrals()
		{
			List<Referral> referrals = new List<Referral>();
			//var client = new RestClient();
			using (var client = new RestClient())
			{
				var request = new RestRequest("https://prod-83.westus.logic.azure.com:443/workflows/403601e44b5241f9b8c6b03685ec25e0/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=a28nMoRCkhrvStFDV_raCqa7FRHO0pXeH1UUpsIPAzQ", Method.Post);
				request.AddHeader("Content-Type", "application/json");
				OutboundReferralDTO referralex = new Referral() { Program = new ReferralProgram() { Id = "6696227998793728", Name = "CCMCN", ProviderName = "Colorado Community Managed Care Network (CCMCN)" } }.ConvertToOutboundReferral();
				referralex.requestType = ReferralsForProgramRequestType;
				var body = JsonConvert.SerializeObject(referralex);
				request.AddParameter("application/json", body, ParameterType.RequestBody);
				RestResponse response = client.Execute(request);
				Console.WriteLine(response.Content);

				try
				{
					InboundResponseDTO inboundResponse = JsonConvert.DeserializeObject<InboundResponseDTO>(response.Content);
					if (inboundResponse != null && inboundResponse.data != null && inboundResponse.data.referrals != null && inboundResponse.success)
					{
						foreach(InboundReferralDTO inboundReferralDTO in inboundResponse.data.referrals)
						{
							referrals.Add(inboundReferralDTO.ConvertToReferral());
						}
					}
					else
					{
						throw new Exception("Unable to POST to get Referrals");
					}
				}
				catch (InvalidCastException ex)
				{
					throw new Exception($"Unable to cast type. Error is {ex.Message}");
				}
			}

			return referrals;
		}


		public void CreateReferral(Referral referral)
		{
			using (var client = new RestClient())
			{
				var request = new RestRequest("https://prod-83.westus.logic.azure.com:443/workflows/403601e44b5241f9b8c6b03685ec25e0/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=a28nMoRCkhrvStFDV_raCqa7FRHO0pXeH1UUpsIPAzQ", Method.Post);
				request.AddHeader("Content-Type", "application/json");
				OutboundReferralDTO referralex = referral.ConvertToOutboundReferral();
				referralex.requestType = CreateReferralRequestType;
				var body = JsonConvert.SerializeObject(referralex);
				request.AddParameter("application/json", body, ParameterType.RequestBody);
				RestResponse response = client.Execute(request);
				Console.WriteLine(response.Content);

			}

		}


		public void UpdateReferral(Referral referral)
		{
			using (var client = new RestClient())
			{
				var request = new RestRequest("https://prod-83.westus.logic.azure.com:443/workflows/403601e44b5241f9b8c6b03685ec25e0/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=a28nMoRCkhrvStFDV_raCqa7FRHO0pXeH1UUpsIPAzQ", Method.Post);
				request.AddHeader("Content-Type", "application/json");
				OutboundReferralDTO referralex = referral.ConvertToOutboundReferral();
				referralex.requestType = UpdateReferralStatusRequestType;
				var body = JsonConvert.SerializeObject(referralex);
				request.AddParameter("application/json", body, ParameterType.RequestBody);
				RestResponse response = client.Execute(request);
				Console.WriteLine(response.Content);

			}

		}


		public List<SelectListItem> GetPrograms(Referral referral)
		{
			List<SelectListItem> programs = new List<SelectListItem>();
			//var client = new RestClient();
			using (var client = new RestClient())
			{
				var request = new RestRequest("https://prod-83.westus.logic.azure.com:443/workflows/403601e44b5241f9b8c6b03685ec25e0/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=a28nMoRCkhrvStFDV_raCqa7FRHO0pXeH1UUpsIPAzQ", Method.Post);
				request.AddHeader("Content-Type", "application/json");
				OutboundReferralDTO referralex = referral.ConvertToOutboundReferral();
				referralex.requestType = SearchProgramsRequestType;
				var body = JsonConvert.SerializeObject(referralex);
				request.AddParameter("application/json", body, ParameterType.RequestBody);
				RestResponse response = client.Execute(request);
				Console.WriteLine(response.Content);

				try
				{
					InboundProgramDTO inboundResponse = JsonConvert.DeserializeObject<InboundProgramDTO>(response.Content);
					if (inboundResponse != null && inboundResponse.programs != null && inboundResponse.programs.Any())
					{
						foreach (ReferralProgramDTO inboundProgramDTO in inboundResponse.programs)
						{
							programs.Add(new SelectListItem() { Value = inboundProgramDTO.id, Text = inboundProgramDTO.name });
						}
					}
					else
					{
						throw new Exception("Unable to POST to get Programs");
					}
				}
				catch (InvalidCastException ex)
				{
					throw new Exception($"Unable to cast type. Error is {ex.Message}");
				}
			}

			return programs;
		}


	}
}
