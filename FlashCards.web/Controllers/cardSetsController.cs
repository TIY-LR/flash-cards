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
using Microsoft.Ajax.Utilities;

namespace FlashCards.web.Controllers
{
    public class CardSetsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/cardSets
        public object GetcardSets()
        {
            return new
            {
                CardSets =
               db.CardSets.Select(cs => new
               {
                   cs.Id,
                   cs.Name,
                   Course = cs.Course.Id,
                   Cards = cs.Cards.Select(c => c.Id)
               }).ToList()
            };

        }

        // GET: api/cardSets/5

        public object GetcardSet(int id)
        {
            return new
            {
                CardSet =
                    db.CardSets.Where(x=>x.Id == id).Select(cs => new
                    {
                        cs.Id,
                        cs.Name,
                        Course = cs.Course.Id,
                        Cards = cs.Cards.Select(c => c.Id)
                    }).ToList().FirstOrDefault()
            };
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

        public IHttpActionResult PostcardSet(CardSetEmberWrapper cardSet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CardSet newCardSet = new CardSet
            {
                Name = cardSet.CardSet.Name,
                Course = db.Courses.Find(cardSet.CardSet.CourseId)

            };
            db.CardSets.Add(newCardSet);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (cardSetExists(newCardSet.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { cardSet = newCardSet });
        }

        // DELETE: api/cardSets/5
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