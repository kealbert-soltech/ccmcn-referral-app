using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ReferralApp.Data;
using ReferralApp.Models;
using ReferralApp.Services;

namespace ReferralApp
{
    public class ReferralsController : Controller
    {
        
        private IReferralService _referralService;

        public ReferralsController(IReferralService referralService)
        {
            _referralService = referralService;
        }

        // GET: Referrals
        public IActionResult Index()
        {
            _referralService.GetBlobs();
            List<Referral> referralList = _referralService.GetReferrals().OrderByDescending(r => r.DateUpdated).ToList();
            HttpContext.Session.SetString("referralList", JsonConvert.SerializeObject(referralList));
            return View(referralList);
        }

        // GET: Referrals/Details/5
        public IActionResult Details(string id)
        {
            List<Referral> referralList = JsonConvert.DeserializeObject<List<Referral>>(HttpContext.Session.GetString("referralList"));

            if (id == null)
            {
                return NotFound();
            }


            Referral referral = referralList.First(r => r.ExistingReferralId == id);
           
            return View(referral);
        }

        // GET: Referrals/Create
        public IActionResult Create()
        {
            ViewData["UserFlow"] = "Get Programs";
            return View();
        }

        // POST: Referrals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Referral referral)
        {
            if (ModelState.IsValid)
            {
                if (referral.RequestType == "GetPrograms")
                {
                    referral.AvailableContactPreferences = new List<string>() { "Email", "Text message", "Phone call","Don't reach out" };
                    referral.AvailablePrograms = _referralService.GetPrograms(referral);
                    ViewData["Languages"] = new SelectList(new List<string>() { "English", "Spanish" });
                    return View(referral);
                }
                else
				{
                    _referralService.CreateReferral(referral);
				}
                return RedirectToAction(nameof(Index));
            }
            referral.AvailableContactPreferences = new List<string>() { "Email", "Text message", "Phone call", "Don't reach out" };
            referral.AvailablePrograms = _referralService.GetPrograms(referral);
            ViewData["Languages"] = new SelectList(new List<string>() { "English", "Spanish" });
            return View(referral);
        }

        // GET: Referrals/Edit/5
        public IActionResult Edit(string id)
        {
            List<Referral> referralList = JsonConvert.DeserializeObject<List<Referral>>(HttpContext.Session.GetString("referralList"));

            if (id == null)
            {
                return NotFound();
            }


            Referral referral = referralList.First(r => r.ExistingReferralId == id);
            if (referral == null)
            {
                return NotFound();
            }
            ViewData["Statuses"] = new SelectList(new List<string>() { "not updated", "needs client action", "pending", "referred elsewhere", "got help", "eligible", "couldn't contact", "not eligible", "no capacity", "couldn't get help", "no longer interested" }, referral.Status);
            return View(referral);
        }

        // POST: Referrals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Status")] Referral referral)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    List<Referral> referralList = JsonConvert.DeserializeObject<List<Referral>>(HttpContext.Session.GetString("referralList"));
                    Referral foundReferral = referralList.First(r => r.ExistingReferralId == id);
                    foundReferral.Status = referral.Status.ToLower();
                    _referralService.UpdateReferral(foundReferral);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferralExists(referral.ExistingReferralId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Statuses"] = new SelectList(new List<string>() { "not updated", "needs client action", "pending", "referred elsewhere", "got help", "eligible", "couldn't contact", "not eligible", "no capacity", "couldn't get help", "no longer interested" }, referral.Status);
            return View(referral);
        }

        // GET: Referrals/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referral = new Referral(); // await _context.Referral.Include(r => r.Program).Include(r => r.Receiver).FirstOrDefaultAsync(m => m.ExistingReferralId == id);
            if (referral == null)
            {
                return NotFound();
            }

            return View(referral);
        }

        // POST: Referrals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var referral = new Referral(); // await _context.Referral.FindAsync(id);
           // _context.Referral.Remove(referral);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferralExists(string id)
        {
            return true; // _context.Referral.Any(e => e.ExistingReferralId == id);
        }

    }
}
