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
	public class AMDController : Controller
	{
		private ApplicationDbContext _context;
		public AMDController()
		{
			_context = new ApplicationDbContext();
		}
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		//
		// GET: /AMD/
		public ActionResult Index()
		{
            var assetsMaintenanceDetails = _context.AssetsMaintenanceDetails.Include(a => a.FixedAsset);
            return View(assetsMaintenanceDetails.ToList());
        }

		public ActionResult MaintenanceDetails()
		{
			var fixedAssets = _context.FixedAssets.ToList();
            var amd = _context.AssetsMaintenanceDetails.ToList();

			var viewModel = new AssetsMaintenanceViewModel
			{
				AssetsMaintenanceDetail = new AssetsMaintenanceDetails(),
				FixedAssets = fixedAssets
			};

			return View("MaintenanceDetails", viewModel);
		}

		public ActionResult AssetsMaintenanceDetails(int id)
		{
			var amd = _context.AssetsMaintenanceDetails.SingleOrDefault(a => a.Id == id);
			if (amd == null)
				return HttpNotFound();
			var viewModel = new AssetsMaintenanceViewModel
			{
				AssetsMaintenanceDetail = amd,
				FixedAssets = _context.FixedAssets.ToList(),
				AssetsMaintenanceDetails = _context.AssetsMaintenanceDetails.ToList()
			};
			return View("MaintenanceDetails", viewModel);
		}
		public ActionResult EditAssetsMD(int id)
		{
			var amd = _context.AssetsMaintenanceDetails.SingleOrDefault(a => a.Id == id);
			if (amd == null)
				return HttpNotFound();
			var viewModel = new AssetsMaintenanceViewModel
			{
				AssetsMaintenanceDetail = amd,
				FixedAssets = _context.FixedAssets.ToList(),
				AssetsMaintenanceDetails = _context.AssetsMaintenanceDetails.ToList()
			};
			return View("MaintenanceDetails", viewModel);
		}

		[HttpPost]
		public ActionResult Save(AssetsMaintenanceDetails assetsMD)
		{
			if(!ModelState.IsValid)
			{
				var viewModel = new AssetsMaintenanceViewModel(assetsMD)
				{
					FixedAssets = _context.FixedAssets.ToList()
				};
				return View("MaintenanceDetails", viewModel);
			}
			if(assetsMD.Id ==0)
			{
				assetsMD.TransactionDate = DateTime.Now;
				_context.AssetsMaintenanceDetails.Add(assetsMD);
			}
			else
			{
				var assetsMDInDb = _context.AssetsMaintenanceDetails.Single(m => m.Id == assetsMD.Id);
				assetsMDInDb.FixedAssetId = assetsMD.FixedAssetId;
				assetsMDInDb.MaintenanceSupervisor = assetsMD.MaintenanceSupervisor;
				assetsMDInDb.TransactionDate = assetsMD.TransactionDate;
				assetsMDInDb.Amount = assetsMD.Amount;
				assetsMDInDb.Maint_Description = assetsMD.Maint_Description;
				assetsMDInDb.GLDebit = assetsMD.GLDebit;
				assetsMDInDb.GLCredit = assetsMD.GLCredit;
			}
			_context.SaveChanges();
			return RedirectToAction("MaintenanceDetails", "AMD");

		}

        // GET: AssetsMaintenanceDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetsMaintenanceDetails assetsMaintenanceDetails = _context.AssetsMaintenanceDetails.Find(id);
            if (assetsMaintenanceDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.FixedAssetId = new SelectList(_context.FixedAssets, "Id", "Description", assetsMaintenanceDetails.FixedAssetId);
            return View(assetsMaintenanceDetails);
        }

        // POST: AssetsMaintenanceDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FixedAssetId,MaintenanceSupervisor,TransactionDate,Amount,Maint_Description,GLDebit,GLCredit")] AssetsMaintenanceDetails assetsMaintenanceDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(assetsMaintenanceDetails).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FixedAssetId = new SelectList(_context.FixedAssets, "Id", "Description", assetsMaintenanceDetails.FixedAssetId);
            return View(assetsMaintenanceDetails);
        }

        // GET: AssetsMaintenanceDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetsMaintenanceDetails assetsMaintenanceDetails = _context.AssetsMaintenanceDetails.Include(a => a.FixedAsset).SingleOrDefault(a => a.Id == id);
            if (assetsMaintenanceDetails == null)
            {
                return HttpNotFound();
            }
            return View(assetsMaintenanceDetails);
        }

        // POST: AssetsMaintenanceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetsMaintenanceDetails assetsMaintenanceDetails = _context.AssetsMaintenanceDetails.Find(id);
            _context.AssetsMaintenanceDetails.Remove(assetsMaintenanceDetails);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}