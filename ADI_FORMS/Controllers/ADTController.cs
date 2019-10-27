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
	public class ADTController : Controller
	{
		private ApplicationDbContext _context;
        //
        // GET: /ADT/
        public ActionResult Index()
        {
            var assetsDisposalDatas = _context.AssetsDisposalDatas.Include(a => a.FixedAsset);
            return View(assetsDisposalDatas.ToList());
        }
        public ADTController()
		{
			_context = new ApplicationDbContext();
		}
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		//
		// GET: /AMD/
		

		public ActionResult DisposalData()
		{
			var fixedAssets = _context.FixedAssets.ToList();

			var assetsDisposalData = _context.AssetsDisposalDatas.ToList();

			var viewModel = new AssetsDisposalDataViewModel
			{
				AssetsDisposalData = new AssetsDisposalData(),
				FixedAssets = fixedAssets
			};

			return View("DisposalData", viewModel);
		}
		public ActionResult EditAssetsDT(int id)
		{
			var adT = _context.AssetsDisposalDatas.SingleOrDefault(a => a.Id == id);
			if (adT == null)
				return HttpNotFound();
			var viewModel = new AssetsDisposalDataViewModel
			{
				AssetsDisposalData = adT,
				FixedAssets = _context.FixedAssets.ToList(),
				AssetsDisposalDatas = _context.AssetsDisposalDatas.ToList()
			};
			return View("DisposalData", viewModel);
		}

		[HttpPost]
		public ActionResult Save(AssetsDisposalData assetsDT)
		{ 
			if(!ModelState.IsValid)
			{
				var viewModel = new AssetsDisposalDataViewModel(assetsDT)
				{
					FixedAssets = _context.FixedAssets.ToList()
				};
				return View("DisposalData", viewModel);
			}
			if(assetsDT.Id ==0)
			{
				assetsDT.DisposalDate = DateTime.Now;
				_context.AssetsDisposalDatas.Add(assetsDT);
			}
			else
			{
				var assetsDTInDb = _context.AssetsDisposalDatas.Single(m => m.Id == assetsDT.Id);
				assetsDTInDb.FixedAssetId = assetsDT.FixedAssetId;
				assetsDTInDb.DisposedValue = assetsDT.DisposedValue;
				assetsDTInDb.DisposalDate = assetsDT.DisposalDate;
				assetsDTInDb.Recipient = assetsDT.Recipient;
				assetsDTInDb.Address = assetsDT.Address;
				assetsDTInDb.Contact = assetsDT.Contact;
			}
			_context.SaveChanges();
			return RedirectToAction("DisposalData", "ADT");

		}
        // GET: AssetsDisposalDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetsDisposalData assetsDisposalData = _context.AssetsDisposalDatas.Find(id);
            if (assetsDisposalData == null)
            {
                return HttpNotFound();
            }
            ViewBag.FixedAssetId = new SelectList(_context.FixedAssets, "Id", "Description", assetsDisposalData.FixedAssetId);
            return View(assetsDisposalData);
        }

        // POST: AssetsDisposalDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FixedAssetId,DisposalDate,DisposedValue,Address,Recipient,Contact")] AssetsDisposalData assetsDisposalData)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(assetsDisposalData).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FixedAssetId = new SelectList(_context.FixedAssets, "Id", "Description", assetsDisposalData.FixedAssetId);
            return View(assetsDisposalData);
        }

        // GET: AssetsDisposalDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetsDisposalData assetsDisposalData = _context.AssetsDisposalDatas.Include(a => a.FixedAsset).SingleOrDefault(a => a.Id == id);
            if (assetsDisposalData == null)
            {
                return HttpNotFound();
            }
            return View(assetsDisposalData);
        }

        // POST: AssetsDisposalDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetsDisposalData assetsDisposalData = _context.AssetsDisposalDatas.Find(id);
            _context.AssetsDisposalDatas.Remove(assetsDisposalData);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}