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
    [EnableCors(origins : "*",headers : "*",methods:"*")]
    public class CardsController : ApiController
    {
      

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Cards
        [ResponseType(typeof(card))]
        public IHttpActionResult GetCards()
        {
            return Json(new { cards= db.Cards.ToList()});
        }
        
        // GET: api/Cards/5
        [ResponseType(typeof(card))]
        public IHttpActionResult GetCard(Guid id)
        {
            card Card = db.Cards.Find(id);
            if (Card == null)
            {
                return NotFound();
            }

            return Ok(Card);
        }

        // PUT: api/Cards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCard(Guid id, card Card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Card.id)
            {
                return BadRequest();
            }

            db.Entry(Card).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
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

        // POST: api/Cards
        [ResponseType(typeof(card))]
        public IHttpActionResult PostCard(card Card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cards.Add(Card);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CardExists(Card.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
           
            return CreatedAtRoute("DefaultApi", new { id = Card.id }, Card);
        }

        // DELETE: api/Cards/5
        [ResponseType(typeof(card))]
        public IHttpActionResult DeleteCard(Guid id)
        {
            card Card = db.Cards.Find(id);
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

        private bool CardExists(Guid id)
        {
            return db.Cards.Count(e => e.id == id) > 0;
        }
    }
}