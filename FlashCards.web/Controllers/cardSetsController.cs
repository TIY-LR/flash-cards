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
    public class CardSetsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/cardSets
        public IHttpActionResult GetcardSets()
        {
            return Json(new { CardSets = db.CardSets.ToList() });
        }

        // GET: api/cardSets/5
        [ResponseType(typeof(CardSet))]
        public IHttpActionResult GetcardSet(Guid id)
        {
            CardSet cardSet = db.CardSets.Find(id);
            if (cardSet == null)
            {
                return NotFound();
            }

            return Ok(cardSet);
        }

        // PUT: api/cardSets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutcardSet(int id, CardSet cardSet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cardSet.Id)
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
        [ResponseType(typeof(CardSet))]
        public IHttpActionResult PostcardSet(CardSet cardSet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CardSets.Add(cardSet);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (cardSetExists(cardSet.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cardSet.Id }, cardSet);
        }

        // DELETE: api/cardSets/5
        [ResponseType(typeof(CardSet))]
        public IHttpActionResult DeletecardSet(Guid id)
        {
            CardSet cardSet = db.CardSets.Find(id);
            if (cardSet == null)
            {
                return NotFound();
            }

            db.CardSets.Remove(cardSet);
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

        private bool cardSetExists(int id)
        {
            return db.CardSets.Count(e => e.Id == id) > 0;
        }
    }
}