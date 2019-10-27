using ADI_FORMS.Models;
using ADI_FORMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ADI_FORMS.Controllers
{
	public class AULController : Controller
	{

		private ApplicationDbContext _context;
		public AULController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ActionResult UsageLog()
		{
			var fixedAssets = _context.FixedAssets.ToList();
			var assetsUsageLogs = _context.AssetUsagelogs.ToList();

			var viewModel = new AssetUsageLogViewModel
			{
				AssetUsageLog = new AssetUsageLog(),
				FixedAssets = fixedAssets
			};

			return View("UsageLog", viewModel);
		}

		[HttpPost]
		public ActionResult Save(AssetUsageLog assetsUL)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new AssetUsageLogViewModel(assetsUL)
				{
					FixedAssets = _context.FixedAssets.ToList()
				};
				return View("UsageLog", viewModel);
			}
			if (assetsUL.Id == 0)
			{
				assetsUL.Trans_Date = DateTime.Now;
				_context.AssetUsagelogs.Add(assetsUL);
			}
			else
			{
				var assetsULInDb = _context.AssetUsagelogs.Single(m => m.Id == assetsUL.Id);
				assetsULInDb.FixedAssetId = assetsUL.FixedAssetId;
				assetsULInDb.Trans_Date = assetsUL.Trans_Date;
				assetsULInDb.StartTime = assetsUL.StartTime;
				assetsULInDb.EndDate = assetsUL.EndDate;
				assetsULInDb.Destination = assetsUL.Destination;
				assetsULInDb.StaffIdentification = assetsUL.StaffIdentification;
			}
			_context.SaveChanges();
			return RedirectToAction("UsageLog", "AUL");

		}

		//
		// GET: /AUL/
		public ActionResult Index()
		{
			return View();
		}

        // GET: AssetUsageLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetUsageLog assetUsageLog = _context.AssetUsagelogs.Find(id);
            if (assetUsageLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.FixedAssetId = new SelectList(_context.FixedAssets, "Id", "Description", assetUsageLog.FixedAssetId);
            return View(assetUsageLog);
        }

        // POST: AssetUsageLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FixedAssetId,Trans_Date,StartTime,EndDate,Destination,StaffIdentification")] AssetUsageLog assetUsageLog)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(assetUsageLog).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FixedAssetId = new SelectList(_context.FixedAssets, "Id", "Description", assetUsageLog.FixedAssetId);
            return View(assetUsageLog);
        }

        // GET: AssetUsageLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //AssetUsageLog assetUsageLog = _context.AssetUsagelogs.Find(id);
            AssetUsageLog assetUsageLog = _context.AssetUsagelogs.Include(a => a.FixedAsset).SingleOrDefault(a => a.Id == id);

            if (assetUsageLog == null)
            {
                return HttpNotFound();
            }
            return View(assetUsageLog);
        }

        // POST: AssetUsageLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetUsageLog assetUsageLog = _context.AssetUsagelogs.Find(id);
            _context.AssetUsagelogs.Remove(assetUsageLog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}