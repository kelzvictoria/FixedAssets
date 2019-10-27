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
    public class AssetsValuationDetailsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AssetsValuationDetails
        public IQueryable<AssetsValuationDetail> GetAssetsValuationDetails()
        {
            return db.AssetsValuationDetails.Include(a => a.DepreciationMTD).Include(a => a.FixedAsset);
        }

        // GET: api/AssetsValuationDetails/5
        [ResponseType(typeof(AssetsValuationDetail))]
        public IHttpActionResult GetAssetsValuationDetail(int id)
        {
            AssetsValuationDetail assetsValuationDetail = db.AssetsValuationDetails.Find(id);
            if (assetsValuationDetail == null)
            {
                return NotFound();
            }

            return Ok(assetsValuationDetail);
        }

        // PUT: api/AssetsValuationDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssetsValuationDetail(int id, AssetsValuationDetail assetsValuationDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assetsValuationDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(assetsValuationDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetsValuationDetailExists(id))
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

        // POST: api/AssetsValuationDetails
        [ResponseType(typeof(AssetsValuationDetail))]
        public IHttpActionResult PostAssetsValuationDetail(AssetsValuationDetail assetsValuationDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AssetsValuationDetails.Add(assetsValuationDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assetsValuationDetail.Id }, assetsValuationDetail);
        }

        // DELETE: api/AssetsValuationDetails/5
        [ResponseType(typeof(AssetsValuationDetail))]
        public IHttpActionResult DeleteAssetsValuationDetail(int id)
        {
            AssetsValuationDetail assetsValuationDetail = db.AssetsValuationDetails.Find(id);
            if (assetsValuationDetail == null)
            {
                return NotFound();
            }

            db.AssetsValuationDetails.Remove(assetsValuationDetail);
            db.SaveChanges();

            return Ok(assetsValuationDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssetsValuationDetailExists(int id)
        {
            return db.AssetsValuationDetails.Count(e => e.Id == id) > 0;
        }
    }
}