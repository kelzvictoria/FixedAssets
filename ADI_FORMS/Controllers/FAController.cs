using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADI_FORMS.ViewModels;
using System.Net;

namespace ADI_FORMS.Controllers
{
	public class FAController : Controller
	{
		private ApplicationDbContext _context;

		public FAController()
		{
			_context = new ApplicationDbContext();
		}

       
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		//
		// GET: /FA/
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult RegisterAsset()
		{
			var categories = _context.Categories.ToList();
			var vendors = _context.Vendors.ToList();
			var branches = _context.Branches.ToList();
			var locations = _context.Locations.ToList();
			var assetStatus = _context.AssetStatus.ToList();
			var assetMaintenanceIntervals = _context.AssetMaintenanceIntervals.ToList();
			var fixedAssets = _context.FixedAssets.ToList();
			var companies = _context.Companies.ToList();
            var deprIntervals = _context.DeprIntervals.ToList();
            var deprMTDs = _context.DepreciationMTDs.ToList();
            var months = _context.Months.ToList();

			var viewModel = new RegisterAssetViewModel
			{
				FixedAsset = new FixedAsset(),
				Categories = categories,
				Vendors = vendors,
				Branches = branches,
				Locations = locations,
				AssetStatus = assetStatus,
				AssetMaintenanceIntervals = assetMaintenanceIntervals,
				Companies = companies,
				FixedAssets = fixedAssets,
                DeprIntervals = deprIntervals,
                DepreciationMTDs = deprMTDs,
                Months = months
			};
			return View("RegisterAsset", viewModel);
		}

		public ActionResult Edit(int id)
		{
			var fa = _context.FixedAssets.SingleOrDefault(f => f.Id == id);
			if (fa == null)
				return HttpNotFound();
			var viewModel = new RegisterAssetViewModel
			{
				FixedAsset = fa,
				Categories = _context.Categories.ToList(),
				Vendors = _context.Vendors.ToList(),
				Branches = _context.Branches.ToList(),
				Locations = _context.Locations.ToList(),
				AssetStatus = _context.AssetStatus.ToList(),
				AssetMaintenanceIntervals = _context.AssetMaintenanceIntervals.ToList(),
				Companies = _context.Companies.ToList(),
				FixedAssets = _context.FixedAssets.ToList(),
                DeprIntervals = _context.DeprIntervals,
                DepreciationMTDs = _context.DepreciationMTDs.ToList(),
                Months = _context.Months.ToList()
            };
			return View("RegisterAsset", viewModel);
		}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FixedAsset fixedAsset = _context.FixedAssets.Find(id);
            if (fixedAsset == null)
            {
                return HttpNotFound();
            }
            return View(fixedAsset);
        }

        // POST: FixedAssets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FixedAsset fixedAsset = _context.FixedAssets.Find(id);
            _context.FixedAssets.Remove(fixedAsset);
            _context.SaveChanges();
            return RedirectToAction("Admin", "Home" );
        }
        public ActionResult Assets(int id)
		{
			var fa = _context.FixedAssets.SingleOrDefault(f => f.Id == id);
			if (fa == null)
				return HttpNotFound();
			var viewModel = new RegisterAssetViewModel
			{
				FixedAsset = fa,
				Categories = _context.Categories.ToList(),
				Vendors = _context.Vendors.ToList(),
				Branches = _context.Branches.ToList(),
				Locations = _context.Locations.ToList(),
				AssetStatus = _context.AssetStatus.ToList(),
				AssetMaintenanceIntervals = _context.AssetMaintenanceIntervals.ToList(),
				Companies = _context.Companies.ToList(),
				FixedAssets = _context.FixedAssets.ToList(),
                DeprIntervals = _context.DeprIntervals,
                DepreciationMTDs = _context.DepreciationMTDs.ToList(),
                Months = _context.Months.ToList()
            };
			return View("RegisterAsset", viewModel);
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public ActionResult Save(FixedAsset fixedAsset)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new RegisterAssetViewModel(fixedAsset)
				{
					Categories = _context.Categories.ToList(),
					Vendors = _context.Vendors.ToList(),
					Branches = _context.Branches.ToList(),
					Locations = _context.Locations.ToList(),
					AssetStatus = _context.AssetStatus.ToList(),
					AssetMaintenanceIntervals = _context.AssetMaintenanceIntervals.ToList(),
					Companies = _context.Companies.ToList(),
                    DeprIntervals = _context.DeprIntervals,
                    DepreciationMTDs = _context.DepreciationMTDs.ToList(),
                    Months = _context.Months.ToList()
                };
				return View("RegisterAsset", viewModel);
			}

			
			if (fixedAsset.Id == 0)
			{
				fixedAsset.DateRegistered = DateTime.Now;
				fixedAsset.PresentValue = fixedAsset.InitialCost;
				_context.FixedAssets.Add(fixedAsset);
			}
			else
			{
				var assetInDb = _context.FixedAssets.Single(a => a.Id == fixedAsset.Id);
				assetInDb.Description = fixedAsset.Description;
				assetInDb.CategoryId = fixedAsset.CategoryId ;
				assetInDb.BranchId = fixedAsset.BranchId;
				assetInDb.LocationId = fixedAsset.LocationId;
				assetInDb.StaffAssigned = fixedAsset.StaffAssigned;
				assetInDb.InitialCost = fixedAsset.InitialCost;
				assetInDb.AssetStatusId = fixedAsset.AssetStatusId;
				assetInDb.SerialNo = fixedAsset.SerialNo;
				assetInDb.PurchasesOrderNo = fixedAsset.PurchasesOrderNo;
				assetInDb.Model = fixedAsset.Model;
				assetInDb.PurchaseRecptNo = fixedAsset.PurchaseRecptNo;
				assetInDb.VendorId = fixedAsset.VendorId;
				assetInDb.YearOfManufacture = fixedAsset.YearOfManufacture;
				assetInDb.PurchasedDate = fixedAsset.PurchasedDate;
				assetInDb.AssetAccountNo = fixedAsset.AssetAccountNo;
				assetInDb.EngineNo = fixedAsset.EngineNo;
				assetInDb.ClassicNo = fixedAsset.ClassicNo;
				assetInDb.AssetMaintenanceIntervalId = fixedAsset.AssetMaintenanceIntervalId;
				assetInDb.MaintenanceFigure = fixedAsset.MaintenanceFigure;
				assetInDb.CompanyId = fixedAsset.CompanyId;
				assetInDb.PresentValue = fixedAsset.PresentValue;
				assetInDb.DateRegistered = fixedAsset.DateRegistered;
				assetInDb.LastValuationDate = fixedAsset.LastValuationDate;
				assetInDb.DeprIntervalId = fixedAsset.DeprIntervalId;
				assetInDb.LifeSpan = fixedAsset.LifeSpan;
				assetInDb.MonthsId = fixedAsset.MonthsId;
				assetInDb.LastDeprYear = fixedAsset.LastDeprYear;
				assetInDb.Residual = fixedAsset.Residual;
				assetInDb.AnnualDeprAmount = fixedAsset.AnnualDeprAmount;
				assetInDb.DepreciationRate = fixedAsset.DepreciationRate;
				assetInDb.LastDeprDate = fixedAsset.LastDeprDate;
				assetInDb.LastDeprAmt = fixedAsset.LastDeprAmt;
				assetInDb.DeprYTD = fixedAsset.DeprYTD;
				assetInDb.DeprToDate = fixedAsset.DeprToDate;
				assetInDb.GLDebitAcc = fixedAsset.GLDebitAcc;
				assetInDb.GLCreditAcc = fixedAsset.GLCreditAcc;
				assetInDb.DepreciationMTDId = fixedAsset.DepreciationMTDId;
				assetInDb.DeprCommenced = fixedAsset.DeprCommenced;
				assetInDb.DeprEndDate = fixedAsset.DeprEndDate;
				assetInDb.CurrentYear = fixedAsset.CurrentYear;
			}
			_context.SaveChanges();
      
			return RedirectToAction("RegisterAsset", "FA");
		}
	}

}