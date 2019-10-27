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
	public class AVDController : Controller
	{
		private ApplicationDbContext _context;
		public AVDController()
		{
			_context = new ApplicationDbContext();
		}
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		
		public ActionResult Index()
		{
            var assetsValuationDetails = _context.AssetsValuationDetails.Include(a => a.DepreciationMTD).Include(a => a.FixedAsset);
            return View(assetsValuationDetails.ToList());
        }

		public ActionResult ValuationDetails()
		{
			var fixedAssets = _context.FixedAssets.ToList();
            var dm = _context.DepreciationMTDs.ToList();
			var assetsValuationDetails = _context.AssetsValuationDetails.ToList();

			var viewModel = new AssetsValuationDetailViewModel
			{
				AssetsValuationDetail = new AssetsValuationDetail(),
				FixedAssets = fixedAssets,
                DepreciationMTDs = dm
			};

			return View("ValuationDetails", viewModel);
		}
		//public ActionResult EditAssetsVD(int id)
		//{
		//	var avd = _context.AssetsValuationDetails.SingleOrDefault(a => a.Id == id);
		//	if (avd == null)
		//		return HttpNotFound();
		//	var viewModel = new AssetsValuationDetailViewModel
		//	{
		//		AssetsValuationDetail = avd,
		//		FixedAssets = _context.FixedAssets.ToList(),
		//		AssetsValuationDetails = _context.AssetsValuationDetails.ToList()
		//	};
		//	return View("ValuationDetails", viewModel);
		//}

		[HttpPost]
		public ActionResult Save(AssetsValuationDetail assetsVD)
		{
			if(!ModelState.IsValid)
			{
				var viewModel = new AssetsValuationDetailViewModel(assetsVD)
				{
					FixedAssets = _context.FixedAssets.ToList(),
                    DepreciationMTDs = _context.DepreciationMTDs.ToList()
				};
				return View("ValuationDetails", viewModel);
			}
			if(assetsVD.Id ==0)
			{
                assetsVD.TransDate = DateTime.Now;
				_context.AssetsValuationDetails.Add(assetsVD);
			}
			else
			{
				var assetsVDInDb = _context.AssetsValuationDetails.Single(m => m.Id == assetsVD.Id);
				assetsVDInDb.FixedAssetId = assetsVD.FixedAssetId;
                assetsVDInDb.DepreciationMTDId = assetsVD.DepreciationMTDId;
				assetsVDInDb.LastValDate = assetsVD.LastValDate;
				assetsVDInDb.Eff_Date = assetsVD.Eff_Date;
				assetsVDInDb.NewDeprMethod = assetsVD.NewDeprMethod;
				assetsVDInDb.NewLifeSpan = assetsVD.NewLifeSpan;
				assetsVDInDb.NewResidual = assetsVD.NewResidual;
				assetsVDInDb.NewDeprStartDate = assetsVD.NewDeprStartDate;
				assetsVDInDb.FirstSalesValue = assetsVD.FirstSalesValue;
				assetsVDInDb.NewDeprToDate = assetsVD.NewDeprToDate;
				assetsVDInDb.NewDeprYearToDate = assetsVD.NewDeprYearToDate;
				assetsVDInDb.NewDeprAmount = assetsVD.NewDeprAmount;
				assetsVDInDb.NewDeprRate = assetsVD.NewDeprRate;
			}
			_context.SaveChanges();
			return RedirectToAction("ValuationDetails", "AVD");

		}

        // GET: AssetsValuationDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetsValuationDetail assetsValuationDetail = _context.AssetsValuationDetails.Find(id);
            if (assetsValuationDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepreciationMTDId = new SelectList(_context.DepreciationMTDs, "Id", "Name", assetsValuationDetail.DepreciationMTDId);
            ViewBag.FixedAssetId = new SelectList(_context.FixedAssets, "Id", "Description", assetsValuationDetail.FixedAssetId);
            return View(assetsValuationDetail);
        }

        // POST: AssetsValuationDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FixedAssetId,DepreciationMTDId,LifeSpan,LastValDate,Eff_Date,NewDeprMethod,NewLifeSpan,NewResidual,NewDeprStartDate,NewDeprRate,FirstSalesValue,NewDeprToDate,NewDeprYearToDate,NewDeprAmount,TransDate")] AssetsValuationDetail assetsValuationDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(assetsValuationDetail).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepreciationMTDId = new SelectList(_context.DepreciationMTDs, "Id", "Name", assetsValuationDetail.DepreciationMTDId);
            ViewBag.FixedAssetId = new SelectList(_context.FixedAssets, "Id", "Description", assetsValuationDetail.FixedAssetId);
            return View(assetsValuationDetail);
        }

        // GET: AssetsValuationDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetsValuationDetail assetsValuationDetail = _context.AssetsValuationDetails.Include(a => a.FixedAsset).SingleOrDefault(a => a.Id == id);
            if (assetsValuationDetail == null)
            {
                return HttpNotFound();
            }
            return View(assetsValuationDetail);
        }

        // POST: AssetsValuationDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetsValuationDetail assetsValuationDetail = _context.AssetsValuationDetails.Find(id);
            _context.AssetsValuationDetails.Remove(assetsValuationDetail);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
