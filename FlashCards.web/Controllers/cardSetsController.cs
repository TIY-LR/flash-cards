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
                    db.CardSets.Where(x => x.Id == id).Select(cs => new
                    {
                        cs.Id,
                        cs.Name,
                        Course = cs.Course.Id,
                        Cards = cs.Cards.Select(c => c.Id)
                    }).ToList().FirstOrDefault()
            };
        }

        // POST: api/cardSets
        public IHttpActionResult PostcardSet(EmberWrapper wrappedCardSet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CardSet newCardSet = new CardSet
            {
                Name = wrappedCardSet.CardSet.Name,
                Course = db.Courses.Find(wrappedCardSet.CardSet.Course)
            };

            db.CardSets.Add(newCardSet);
            db.SaveChanges();

            wrappedCardSet.CardSet.Course = newCardSet.Course.Id;
            wrappedCardSet.CardSet.Id = newCardSet.Id;

            return Ok(new { cardSet = wrappedCardSet.CardSet });
        }

        // DELETE: api/cardSets/5
        public IHttpActionResult DeletecardSet(int id)
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