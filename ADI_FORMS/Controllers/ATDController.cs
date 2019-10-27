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
	public class ATDController : Controller
	{
		private ApplicationDbContext _context;
		public ATDController()
		{
			_context = new ApplicationDbContext();
		}
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		//
		// GET: /ATD/
		public ActionResult Index()
		{
            var assetsTransferDatas = _context.AssetsTransferDatas.Include(a => a.FixedAsset);
            return View(assetsTransferDatas.ToList());
        }

		public ActionResult TransferData()
		{
			var fixedAssets = _context.FixedAssets.ToList();
			//var locations = _context.Locations.ToList();
			//var branches = _context.Branches.ToList();
			//var companies = _context.Companies.ToList();
            var assetsTransferData = _context.AssetsTransferDatas.ToList();

            var viewModel = new AssetsTransferDataViewModel
			{
				AssetsTransferData = new AssetsTransferData(),
				FixedAssets = fixedAssets
				//Locations = locations,
				//Branches = branches,
				//Companies = companies
			};

			return View("TransferData", viewModel);
		}
		public ActionResult EditAssetsTD(int id)
		{
			var atd = _context.AssetsTransferDatas.SingleOrDefault(a => a.Id == id);
			if (atd == null)
				return HttpNotFound();
			var viewModel = new AssetsTransferDataViewModel
			{
				AssetsTransferData = atd,
				FixedAssets = _context.FixedAssets.ToList(),
				AssetsTransferDatas = _context.AssetsTransferDatas.ToList()
			};
			return View("TransferData", viewModel);
		}

		[HttpPost]
		public ActionResult Save(AssetsTransferData assetsTD)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new AssetsTransferDataViewModel(assetsTD)
				{
					FixedAssets = _context.FixedAssets.ToList()
					//Locations = _context.Locations.ToList(),
					//Branches = _context.Branches.ToList(),
					//Companies = _context.Companies.ToList()
				};
				return View("ValuationDetails", viewModel);
			}
			if (assetsTD.Id == 0)
			{
                assetsTD.TransferDate = DateTime.Now;
				_context.AssetsTransferDatas.Add(assetsTD);
			}
			else
			{
				var assetsTDInDb = _context.AssetsTransferDatas.Single(m => m.Id == assetsTD.Id);
				assetsTDInDb.FixedAssetId = assetsTD.FixedAssetId;
                assetsTDInDb.NewBranch = assetsTD.NewBranch;
                assetsTDInDb.NewCompany = assetsTD.NewCompany;
                assetsTDInDb.NewLocation = assetsTD.NewLocation;
                assetsTDInDb.TransferDate = assetsTD.TransferDate;
			}
			_context.SaveChanges();
			return RedirectToAction("TransferData", "ATD");
		}

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetsTransferData assetsTransferData = _context.AssetsTransferDatas.Find(id);
            if (assetsTransferData == null)
            {
                return HttpNotFound();
            }
            ViewBag.FixedAssetId = new SelectList(_context.FixedAssets, "Id", "Description", assetsTransferData.FixedAssetId);
            return View(assetsTransferData);
        }

        // POST: AssetsTransferDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FixedAssetId,NewLocation,NewCompany,NewBranch,TransferDate")] AssetsTransferData assetsTransferData)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(assetsTransferData).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FixedAssetId = new SelectList(_context.FixedAssets, "Id", "Description", assetsTransferData.FixedAssetId);
            return View(assetsTransferData);
        }

        // GET: AssetsTransferDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetsTransferData assetsTransferData = _context.AssetsTransferDatas.Include(a => a.FixedAsset).SingleOrDefault(a => a.Id == id);
            if (assetsTransferData == null)
            {
                return HttpNotFound();
            }
            return View(assetsTransferData);
        }

        // POST: AssetsTransferDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetsTransferData assetsTransferData = _context.AssetsTransferDatas.Find(id);
            _context.AssetsTransferDatas.Remove(assetsTransferData);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}