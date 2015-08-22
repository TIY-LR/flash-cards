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
    public class TestModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TestModels
        public IQueryable<TestModel> GetTestModels()
        {
            return db.TestModels;
        }
        
        // GET: api/TestModels/5
        [ResponseType(typeof(TestModel))]
        public IHttpActionResult GetTestModel(Guid id)
        {
            TestModel testModel = db.TestModels.Find(id);
            if (testModel == null)
            {
                return NotFound();
            }

            return Ok(testModel);
        }

        // PUT: api/TestModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestModel(Guid id, TestModel testModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testModel.Id)
            {
                return BadRequest();
            }

            db.Entry(testModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestModelExists(id))
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

        // POST: api/TestModels
        [ResponseType(typeof(TestModel))]
        public IHttpActionResult PostTestModel(TestModel testModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TestModels.Add(testModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TestModelExists(testModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = testModel.Id }, testModel);
        }

        // DELETE: api/TestModels/5
        [ResponseType(typeof(TestModel))]
        public IHttpActionResult DeleteTestModel(Guid id)
        {
            TestModel testModel = db.TestModels.Find(id);
            if (testModel == null)
            {
                return NotFound();
            }

            db.TestModels.Remove(testModel);
            db.SaveChanges();

            return Ok(testModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestModelExists(Guid id)
        {
            return db.TestModels.Count(e => e.Id == id) > 0;
        }
    }
}