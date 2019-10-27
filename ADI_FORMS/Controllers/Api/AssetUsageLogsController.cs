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
    public class AssetUsageLogsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AssetUsageLogs
        public IQueryable<AssetUsageLog> GetAssetUsagelogs()
        {
            return db.AssetUsagelogs.Include(m => m.FixedAsset);
        }

        // GET: api/AssetUsageLogs/5
        [ResponseType(typeof(AssetUsageLog))]
        public IHttpActionResult GetAssetUsageLog(int id)
        {
            AssetUsageLog assetUsageLog = db.AssetUsagelogs.Find(id);
            if (assetUsageLog == null)
            {
                return NotFound();
            }

            return Ok(assetUsageLog);
        }

        // PUT: api/AssetUsageLogs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssetUsageLog(int id, AssetUsageLog assetUsageLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assetUsageLog.Id)
            {
                return BadRequest();
            }

            db.Entry(assetUsageLog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetUsageLogExists(id))
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

        // POST: api/AssetUsageLogs
        [ResponseType(typeof(AssetUsageLog))]
        public IHttpActionResult PostAssetUsageLog(AssetUsageLog assetUsageLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AssetUsagelogs.Add(assetUsageLog);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assetUsageLog.Id }, assetUsageLog);
        }

        //DELETE: api/AssetUsageLogs/5
        [ResponseType(typeof(AssetUsageLog))]
        public IHttpActionResult DeleteAssetUsageLog(int id)
        {
            AssetUsageLog assetUsageLog = db.AssetUsagelogs.Find(id);
            if (assetUsageLog == null)
            {
                return NotFound();
            }

            db.AssetUsagelogs.Remove(assetUsageLog);
            db.SaveChanges();

            return Ok(assetUsageLog);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssetUsageLogExists(int id)
        {
            return db.AssetUsagelogs.Count(e => e.Id == id) > 0;
        }
    }
}