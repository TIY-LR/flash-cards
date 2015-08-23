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
    public class CoursesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/courses
        // [ResponseType(typeof(Course))]
        public object GetCourse()
        {
            return new 
            {
                Courses =
                db.Courses.Select(c => new
                {
                    c.Id,
                    c.Name,
                    CardSets =
                    c.CardSets.Select(cs => cs.Id)
                }).ToList()
            };
        }

        // GET: api/courses/5
        //[ResponseType(typeof(Course))]
        public object GetCourse(int id)
        {
            return new
            {
                Courses =
                db.Courses.Where(x=>x.Id == id).Select(c => new
                {
                    c.Id,
                    c.Name,
                    CardSets =
                    c.CardSets.Select(cs => cs.Id)
                }).ToList().FirstOrDefault()
            };
        }

        // PUT: api/courses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourse(int id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.Id)
            {
                return BadRequest();
            }

            db.Entry(course).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!courseExists(id))
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

        // POST: api/courses
        public IHttpActionResult Postcourse(EmberWrapper course)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Course newCourse = new Course
            {
                Name = course.Course.Name,
            };

            db.Courses.Add(newCourse);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (courseExists(newCourse.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { course = newCourse });
        }

        // DELETE: api/courses/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult Deletecourse(Guid id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            db.Courses.Remove(course);
            db.SaveChanges();

            return Ok(course);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool courseExists(int id)
        {
            return db.Courses.Count(e => e.Id == id) > 0;
        }
    }
}