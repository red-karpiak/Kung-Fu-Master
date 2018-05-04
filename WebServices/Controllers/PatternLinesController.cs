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
using Kung_Fu_Tracker.Models;
using WebServices.Models;

namespace WebServices.Controllers
{
    public class PatternLinesController : ApiController
    {
        private PatternLinesContext db = new PatternLinesContext();

        // GET: api/PatternLines
        public IQueryable<PatternLine> GetPatternLines()
        {
            return db.PatternLines;
        }

        // GET: api/PatternLines/5
        [ResponseType(typeof(PatternLine))]
        public IHttpActionResult GetPatternLine(int id)
        {
            PatternLine patternLine = db.PatternLines.Find(id);
            if (patternLine == null)
            {
                return NotFound();
            }

            return Ok(patternLine);
        }

        // PUT: api/PatternLines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatternLine(int id, PatternLine patternLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patternLine.Id)
            {
                return BadRequest();
            }

            db.Entry(patternLine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatternLineExists(id))
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

        // POST: api/PatternLines
        [ResponseType(typeof(PatternLine))]
        public IHttpActionResult PostPatternLine(PatternLine patternLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PatternLines.Add(patternLine);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = patternLine.Id }, patternLine);
        }

        // DELETE: api/PatternLines/5
        [ResponseType(typeof(PatternLine))]
        public IHttpActionResult DeletePatternLine(int id)
        {
            PatternLine patternLine = db.PatternLines.Find(id);
            if (patternLine == null)
            {
                return NotFound();
            }

            db.PatternLines.Remove(patternLine);
            db.SaveChanges();

            return Ok(patternLine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatternLineExists(int id)
        {
            return db.PatternLines.Count(e => e.Id == id) > 0;
        }
    }
}