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
    public class AssetsTransferDatasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AssetsTransferDatas
        public IQueryable<AssetsTransferData> GetAssetsTransferDatas()
        {
            return db.AssetsTransferDatas.Include(m=>m.FixedAsset);
        }

        // GET: api/AssetsTransferDatas/5
        [ResponseType(typeof(AssetsTransferData))]
        public IHttpActionResult GetAssetsTransferData(int id)
        {
            AssetsTransferData assetsTransferData = db.AssetsTransferDatas.Find(id);
            if (assetsTransferData == null)
            {
                return NotFound();
            }

            return Ok(assetsTransferData);
        }

        // PUT: api/AssetsTransferDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssetsTransferData(int id, AssetsTransferData assetsTransferData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assetsTransferData.Id)
            {
                return BadRequest();
            }

            db.Entry(assetsTransferData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetsTransferDataExists(id))
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

        // POST: api/AssetsTransferDatas
        [ResponseType(typeof(AssetsTransferData))]
        public IHttpActionResult PostAssetsTransferData(AssetsTransferData assetsTransferData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AssetsTransferDatas.Add(assetsTransferData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assetsTransferData.Id }, assetsTransferData);
        }

        // DELETE: api/AssetsTransferDatas/5
        [ResponseType(typeof(AssetsTransferData))]
        public IHttpActionResult DeleteAssetsTransferData(int id)
        {
            AssetsTransferData assetsTransferData = db.AssetsTransferDatas.Find(id);
            if (assetsTransferData == null)
            {
                return NotFound();
            }

            db.AssetsTransferDatas.Remove(assetsTransferData);
            db.SaveChanges();

            return Ok(assetsTransferData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssetsTransferDataExists(int id)
        {
            return db.AssetsTransferDatas.Count(e => e.Id == id) > 0;
        }
    }
}