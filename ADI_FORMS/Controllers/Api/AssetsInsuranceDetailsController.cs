using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ADI_FORMS.Models;

namespace ADI_FORMS.Controllers.Api
{
    public class AssetsInsuranceDetailsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AssetsInsuranceDetails
        public IQueryable<AssetsInsuranceDetail> GetAssetsInsuranceDetails()
        {
            return db.AssetsInsuranceDetails.Include(a => a.FixedAsset);
        }

        // GET: api/AssetsInsuranceDetails/5
        [ResponseType(typeof(AssetsInsuranceDetail))]
        public IHttpActionResult GetAssetsInsuranceDetail(int id)
        {
            AssetsInsuranceDetail assetsInsuranceDetail = db.AssetsInsuranceDetails.Find(id);
            if (assetsInsuranceDetail == null)
            {
                return NotFound();
            }

            return Ok(assetsInsuranceDetail);
        }

        // PUT: api/AssetsInsuranceDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssetsInsuranceDetail(int id, AssetsInsuranceDetail assetsInsuranceDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assetsInsuranceDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(assetsInsuranceDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetsInsuranceDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AssetsInsuranceDetails
        [ResponseType(typeof(AssetsInsuranceDetail))]
        public IHttpActionResult PostAssetsInsuranceDetail(AssetsInsuranceDetail assetsInsuranceDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AssetsInsuranceDetails.Add(assetsInsuranceDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assetsInsuranceDetail.Id }, assetsInsuranceDetail);
        }

        // DELETE: api/AssetsInsuranceDetails/5
        [ResponseType(typeof(AssetsInsuranceDetail))]
        public IHttpActionResult DeleteAssetsInsuranceDetail(int id)
        {
            AssetsInsuranceDetail assetsInsuranceDetail = db.AssetsInsuranceDetails.Find(id);
            if (assetsInsuranceDetail == null)
            {
                return NotFound();
            }

            db.AssetsInsuranceDetails.Remove(assetsInsuranceDetail);
            db.SaveChanges();

            return Ok(assetsInsuranceDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssetsInsuranceDetailExists(int id)
        {
            return db.AssetsInsuranceDetails.Count(e => e.Id == id) > 0;
        }
    }
}