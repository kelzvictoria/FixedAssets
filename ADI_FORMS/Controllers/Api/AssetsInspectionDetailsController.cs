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
    public class AssetsInspectionDetailsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AssetsInspectionDetails
        public IQueryable<AssetsInspectionDetails> GetAssetsInspectionDetail()
        {
            return db.AssetsInspectionDetail.Include(a => a.AssetStatus).Include(a => a.FixedAsset);
        }

        // GET: api/AssetsInspectionDetails/5
        [ResponseType(typeof(AssetsInspectionDetails))]
        public IHttpActionResult GetAssetsInspectionDetails(int id)
        {
            AssetsInspectionDetails assetsInspectionDetails = db.AssetsInspectionDetail.Find(id);
            if (assetsInspectionDetails == null)
            {
                return NotFound();
            }

            return Ok(assetsInspectionDetails);
        }

        // PUT: api/AssetsInspectionDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssetsInspectionDetails(int id, AssetsInspectionDetails assetsInspectionDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assetsInspectionDetails.Id)
            {
                return BadRequest();
            }

            db.Entry(assetsInspectionDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetsInspectionDetailsExists(id))
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

        // POST: api/AssetsInspectionDetails
        [ResponseType(typeof(AssetsInspectionDetails))]
        public IHttpActionResult PostAssetsInspectionDetails(AssetsInspectionDetails assetsInspectionDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AssetsInspectionDetail.Add(assetsInspectionDetails);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assetsInspectionDetails.Id }, assetsInspectionDetails);
        }

        // DELETE: api/AssetsInspectionDetails/5
        [ResponseType(typeof(AssetsInspectionDetails))]
        public IHttpActionResult DeleteAssetsInspectionDetails(int id)
        {
            AssetsInspectionDetails assetsInspectionDetails = db.AssetsInspectionDetail.Find(id);
            if (assetsInspectionDetails == null)
            {
                return NotFound();
            }

            db.AssetsInspectionDetail.Remove(assetsInspectionDetails);
            db.SaveChanges();

            return Ok(assetsInspectionDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssetsInspectionDetailsExists(int id)
        {
            return db.AssetsInspectionDetail.Count(e => e.Id == id) > 0;
        }
    }
}