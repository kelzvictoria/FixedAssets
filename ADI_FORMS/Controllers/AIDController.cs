using ADI_FORMS.Models;
using ADI_FORMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ADI_FORMS.Controllers
{
    public class AIDController : Controller
    {
        private ApplicationDbContext _context;
        public AIDController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult InsuranceDetails()
        {
            var fixedAssets = _context.FixedAssets.ToList();

            var assetsInsuranceDetail = _context.AssetsInsuranceDetails.ToList();

            var viewModel = new AssetsInsuranceDetailViewModel
            {
                AssetsInsuranceDetail = new AssetsInsuranceDetail(),
                FixedAssets = fixedAssets
                
            };

            return View("InsuranceDetails", viewModel);
        }

        [HttpPost]
        public ActionResult Save(AssetsInsuranceDetail assetsID)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AssetsInsuranceDetailViewModel(assetsID)
                {
                    FixedAssets = _context.FixedAssets.ToList()
                };
                return View("InsuranceDetails", viewModel);
            }
            if (assetsID.Id == 0)
            {
                _context.AssetsInsuranceDetails.Add(assetsID);
            }
            else
            {
                var assetsIDInDb = _context.AssetsInsuranceDetails.Single(m => m.Id == assetsID.Id);
                assetsIDInDb.FixedAssetId = assetsID.FixedAssetId;
                assetsIDInDb.InsuranceCompany = assetsID.InsuranceCompany;
                assetsIDInDb.Address = assetsID.Address;
                assetsIDInDb.InsuredValue = assetsID.InsuredValue;
                assetsIDInDb.InsurancePremium = assetsID.InsurancePremium;
                assetsIDInDb.PremiumToDate = assetsID.PremiumToDate;
                assetsIDInDb.Interval = assetsID.Interval;
                assetsIDInDb.DueDate = assetsID.DueDate;
                assetsIDInDb.DatePaid = assetsID.DatePaid;
                assetsIDInDb.DateFirstInsured = assetsID.DateFirstInsured;
                assetsIDInDb.PayMode = assetsID.PayMode;
                assetsIDInDb .PremiumPayable= assetsID.PremiumPayable;
            }
            _context.SaveChanges();
            return RedirectToAction("InsuranceDetails", "AID");

        }
        public ActionResult Index()
        {
            var assetsInsuranceDetails = _context.AssetsInsuranceDetails.Include(a => a.FixedAsset);
            return View(assetsInsuranceDetails.ToList());
        }

        // GET: AssetsInsuranceDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetsInsuranceDetail assetsInsuranceDetail = _context.AssetsInsuranceDetails.Find(id);
            if (assetsInsuranceDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.FixedAssetId = new SelectList(_context.FixedAssets, "Id", "Description", assetsInsuranceDetail.FixedAssetId);
            return View(assetsInsuranceDetail);
        }

        // POST: AssetsInsuranceDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FixedAssetId,PeriodFrom,PeriodTo,InsuranceCompany,Address,InsuredValue,InsurancePremium,PremiumToDate,DateFirstInsured,PremiumPayable,Interval,DueDate,DatePaid,PayMode,PolicyNo")] AssetsInsuranceDetail assetsInsuranceDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(assetsInsuranceDetail).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FixedAssetId = new SelectList(_context.FixedAssets, "Id", "Description", assetsInsuranceDetail.FixedAssetId);
            return View(assetsInsuranceDetail);
        }

        // GET: AssetsInsuranceDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetsInsuranceDetail assetsInsuranceDetail = _context.AssetsInsuranceDetails.Include(a => a.FixedAsset).SingleOrDefault(a => a.Id == id);
            if (assetsInsuranceDetail == null)
            {
                return HttpNotFound();
            }
            return View(assetsInsuranceDetail);
        }

        // POST: AssetsInsuranceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetsInsuranceDetail assetsInsuranceDetail = _context.AssetsInsuranceDetails.Find(id);
            _context.AssetsInsuranceDetails.Remove(assetsInsuranceDetail);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}