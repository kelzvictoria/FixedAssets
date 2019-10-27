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
    public class AssetsDisposalDatasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AssetsDisposalDatas
        public IQueryable<AssetsDisposalData> GetAssetsDisposalDatas()
        {
            return db.AssetsDisposalDatas.Include(m=>m.FixedAsset);
        }

        // GET: api/AssetsDisposalDatas/5
        [ResponseType(typeof(AssetsDisposalData))]
        public IHttpActionResult GetAssetsDisposalData(int id)
        {
            AssetsDisposalData assetsDisposalData = db.AssetsDisposalDatas.Find(id);
            if (assetsDisposalData == null)
            {
                return NotFound();
            }

            return Ok(assetsDisposalData);
        }

        // PUT: api/AssetsDisposalDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssetsDisposalData(int id, AssetsDisposalData assetsDisposalData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assetsDisposalData.Id)
            {
                return BadRequest();
            }

            db.Entry(assetsDisposalData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetsDisposalDataExists(id))
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

        // POST: api/AssetsDisposalDatas
        [ResponseType(typeof(AssetsDisposalData))]
        public IHttpActionResult PostAssetsDisposalData(AssetsDisposalData assetsDisposalData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AssetsDisposalDatas.Add(assetsDisposalData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assetsDisposalData.Id }, assetsDisposalData);
        }

        // DELETE: api/AssetsDisposalDatas/5
        [ResponseType(typeof(AssetsDisposalData))]
        public IHttpActionResult DeleteAssetsDisposalData(int id)
        {
            AssetsDisposalData assetsDisposalData = db.AssetsDisposalDatas.Find(id);
            if (assetsDisposalData == null)
            {
                return NotFound();
            }

            db.AssetsDisposalDatas.Remove(assetsDisposalData);
            db.SaveChanges();

            return Ok(assetsDisposalData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssetsDisposalDataExists(int id)
        {
            return db.AssetsDisposalDatas.Count(e => e.Id == id) > 0;
        }
    }
}