using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using FlashCards.web.Models;

namespace FlashCards.web.Controllers
{
    public class CardsController : ApiController
    {


        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Cards
        [ResponseType(typeof(Card))]
        public IHttpActionResult GetCards()
        {
            return Json(new { cards = db.Cards.ToList() });
        }

        // GET: api/Cards/[id]
        [ResponseType(typeof(Card))]
        public IHttpActionResult GetCard(int id)
        {
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        //// PUT: api/Cards/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCard(int id, Card Card)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != Card.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(Card).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CardExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Cards
        [ResponseType(typeof(Card))]
        public IHttpActionResult PostCard(CardCreateVM card)
        {
            Card newCard = new Card() {FrontText = card.FrontText, BackText = card.BackText};

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cards.Add(newCard);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CardExists(newCard.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = newCard.Id }, newCard);
        }

        // DELETE: api/Cards/5
        [ResponseType(typeof(Card))]
        public IHttpActionResult DeleteCard(Guid id)
        {
            Card Card = db.Cards.Find(id);
            if (Card == null)
            {
                return NotFound();
            }

            db.Cards.Remove(Card);
            db.SaveChanges();

            return Ok(Card);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CardExists(int id)
        {
            return db.Cards.Count(e => e.Id == id) > 0;
        }
    }
}