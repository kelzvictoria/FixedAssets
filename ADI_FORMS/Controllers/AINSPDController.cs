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
	public class AINSPDController : Controller
	{
		private ApplicationDbContext _context;
		public AINSPDController()
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
            var assetsInspectionDetail = _context.AssetsInspectionDetail.Include(a => a.AssetStatus).Include(a => a.FixedAsset);
            return View(assetsInspectionDetail.ToList());
        }

		public ActionResult InspectionDetails()
		{
			var fixedAssets = _context.FixedAssets.ToList();
			var assetStatus = _context.AssetStatus.ToList();
			
			var assetsInspectionDetails = _context.AssetsInspectionDetail.ToList();

			var viewModel = new AssetsInspectionDetailViewModel
			{
				AssetsInspectionDetail = new AssetsInspectionDetails(),
				FixedAssets = fixedAssets  ,
				AssetStatuses = assetStatus
			};

			return View("InspectionDetails", viewModel);
		}
		public ActionResult EditAssetsInspD(int id)
		{
			var aInspD = _context.AssetsInspectionDetail.SingleOrDefault(a => a.Id == id);
			if (aInspD == null)
				return HttpNotFound();
			var viewModel = new AssetsInspectionDetailViewModel
			{
				AssetsInspectionDetail = aInspD,
				FixedAssets = _context.FixedAssets.ToList(),
				AssetsInspectionDetails = _context.AssetsInspectionDetail.ToList()
			};
			return View("InspectionDetails", viewModel);
		}

		[HttpPost]
		public ActionResult Save(AssetsInspectionDetails assetsInspD)
		{
			if(!ModelState.IsValid)
			{
				var viewModel = new AssetsInspectionDetailViewModel(assetsInspD)
				{
					FixedAssets = _context.FixedAssets.ToList(),
					AssetStatuses = _context.AssetStatus.ToList()
				};
				return View("InspectionDetails", viewModel);
			}
			if(assetsInspD.Id ==0)
			{
				assetsInspD.InspectionDate = DateTime.Now;
				_context.AssetsInspectionDetail.Add(assetsInspD);
			}
			else
			{
				var assetsInspDInDb = _context.AssetsInspectionDetail.Single(m => m.Id == assetsInspD.Id);
				assetsInspDInDb.FixedAssetId = assetsInspD.FixedAsset.Id;
				assetsInspDInDb.InspectionDate = assetsInspD.InspectionDate;
				assetsInspDInDb.InspectedBy = assetsInspD.InspectedBy;
				assetsInspDInDb.AssetStatus = assetsInspD.AssetStatus;
				assetsInspDInDb.Remarks = assetsInspD.Remarks;
			}
			_context.SaveChanges();
			return RedirectToAction("InspectionDetails", "AINSPD");

		}

        // GET: AssetsInspectionDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetsInspectionDetails assetsInspectionDetails = _context.AssetsInspectionDetail.Find(id);
            if (assetsInspectionDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetStatusId = new SelectList(_context.AssetStatus, "Id", "Name", assetsInspectionDetails.AssetStatusId);
            ViewBag.FixedAssetId = new SelectList(_context.FixedAssets, "Id", "Description", assetsInspectionDetails.FixedAssetId);
            return View(assetsInspectionDetails);
        }

        // POST: AssetsInspectionDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FixedAssetId,InspectionDate,Inspecte_contexty,AssetStatusId,Remarks")] AssetsInspectionDetails assetsInspectionDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(assetsInspectionDetails).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssetStatusId = new SelectList(_context.AssetStatus, "Id", "Name", assetsInspectionDetails.AssetStatusId);
            ViewBag.FixedAssetId = new SelectList(_context.FixedAssets, "Id", "Description", assetsInspectionDetails.FixedAssetId);
            return View(assetsInspectionDetails);
        }

        // GET: AssetsInspectionDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetsInspectionDetails assetsInspectionDetails = _context.AssetsInspectionDetail.Include(a => a.AssetStatus).Include(a => a.FixedAsset).SingleOrDefault(a => a.Id == id); 
            if (assetsInspectionDetails == null)
            {
                return HttpNotFound();
            }
            return View(assetsInspectionDetails);
        }

        // POST: AssetsInspectionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetsInspectionDetails assetsInspectionDetails = _context.AssetsInspectionDetail.Find(id);
            _context.AssetsInspectionDetail.Remove(assetsInspectionDetails);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}