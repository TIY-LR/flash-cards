using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using FlashCards.web.Models;

namespace FlashCards.web.Controllers
{
    public class CardsController : ApiController
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/Cards
        public object GetCards()
        {
            return new
            {
                Cards = db.Cards.Select(c => new
                {
                    c.Id,
                    c.FrontText,
                    c.BackText,
                    CardSet = c.CardSet.Id
                }).ToList()
            };
        }

        public object GetCard(int id)
        {
            return new
            {
                Card =
                    db.Cards.Where(c => c.Id == id).Select(c => new
                    {
                        c.Id,
                        c.FrontText,
                        c.BackText,
                        CardSet = c.CardSet.Id
                    }).ToList().FirstOrDefault()
            };
        }

        public object PostCard(EmberWrapper wrappedCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Card newCard = new Card
            {
                FrontText = wrappedCard.Card.FrontText,
                BackText = wrappedCard.Card.BackText,
                CardSet = db.CardSets.Find(wrappedCard.Card.CardSet)
            };

            db.Cards.Add(newCard);
            db.SaveChanges();

            wrappedCard.Card.CardSet = newCard.CardSet.Id;
            wrappedCard.Card.Id = newCard.Id;

            return new { card = wrappedCard.Card };
        }

        // DELETE: api/Cards/5
        public IHttpActionResult DeleteCard(int id)
        {
            var Card = db.Cards.Find(id);
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