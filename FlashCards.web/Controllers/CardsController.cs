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
        //[ResponseType(typeof(Card))]
        public object GetCards()
        {
            return new  { Cards = db.Cards.Select(c=> new
            {
                c.Id,
                c.FrontText,
                c.BackText,
                CardSet = c.CardSet.Id
            }).ToList() };
        }


        public object GetCard(int id)
        {
            return new 
            {
                Card =
                    db.Cards.Where(c=>c.Id == id).Select(c => new
                    {
                        c.Id,
                        c.FrontText,
                        c.BackText,
                        CardSet = c.CardSet.Id
                    }).ToList().FirstOrDefault()
            };
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

    public object PostCard(CardCreateVM card)
    {
           
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingCardSet = db.CardSets.Find(card.CardSetId);

        Card newCard = new Card() { FrontText = card.FrontText, BackText = card.BackText, CardSet = existingCardSet };


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

        card.CardId = newCard.Id;

        return new { card = card };
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