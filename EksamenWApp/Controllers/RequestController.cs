﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EksamenWApp;

namespace EksamenWApp.Controllers
{
    public class RequestController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Request
        public IQueryable<RequestDB> GetRequests()
        {
            return db.Requests;
        }

        // GET: api/Request/5
        [ResponseType(typeof(RequestDB))]
        public IHttpActionResult GetRequest(int id)
        {
            RequestDB request = db.Requests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }

        // PUT: api/Request/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequest(int id, RequestDB request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.RequestId)
            {
                return BadRequest();
            }

            db.Entry(request).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        // POST: api/Request
        [ResponseType(typeof(RequestDB))]
        public IHttpActionResult PostRequest(RequestDB request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Requests.Add(request);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = request.RequestId }, request);
        }

        // DELETE: api/Request/5
        [ResponseType(typeof(RequestDB))]
        public IHttpActionResult DeleteRequest(int id)
        {
            RequestDB request = db.Requests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            db.Requests.Remove(request);
            db.SaveChanges();

            return Ok(request);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestExists(int id)
        {
            return db.Requests.Count(e => e.RequestId == id) > 0;
        }
    }
}