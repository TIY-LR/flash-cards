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
using FlashCards.web.Models;

namespace FlashCards.web.Controllers
{
    public class cardSetsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/cardSets
        public IQueryable<cardSet> GetcardSets()
        {
            return db.cardSets;
        }

        // GET: api/cardSets/5
        [ResponseType(typeof(cardSet))]
        public IHttpActionResult GetcardSet(Guid id)
        {
            cardSet cardSet = db.cardSets.Find(id);
            if (cardSet == null)
            {
                return NotFound();
            }

            return Ok(cardSet);
        }

        // PUT: api/cardSets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutcardSet(Guid id, cardSet cardSet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cardSet.id)
            {
                return BadRequest();
            }

            db.Entry(cardSet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cardSetExists(id))
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

        // POST: api/cardSets
        [ResponseType(typeof(cardSet))]
        public IHttpActionResult PostcardSet(cardSet cardSet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cardSets.Add(cardSet);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (cardSetExists(cardSet.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cardSet.id }, cardSet);
        }

        // DELETE: api/cardSets/5
        [ResponseType(typeof(cardSet))]
        public IHttpActionResult DeletecardSet(Guid id)
        {
            cardSet cardSet = db.cardSets.Find(id);
            if (cardSet == null)
            {
                return NotFound();
            }

            db.cardSets.Remove(cardSet);
            db.SaveChanges();

            return Ok(cardSet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cardSetExists(Guid id)
        {
            return db.cardSets.Count(e => e.id == id) > 0;
        }
    }
}