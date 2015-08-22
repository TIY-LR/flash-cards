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
        public IHttpActionResult GetCards()
        {
            return Json(new {Courses= db.Courses.ToList()});
        }

        // GET: api/courses/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult Getcourse(Guid id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // PUT: api/courses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcourse(Guid id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.id)
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
        [ResponseType(typeof(Course))]
        public IHttpActionResult Postcourse(CourseVM course)
        {
            Course newCourse = new Course
            {
                id = Guid.NewGuid(),
                name = course.name,
                description = course.description
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courses.Add(newCourse);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (courseExists(newCourse.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = newCourse.id }, course);
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

        private bool courseExists(Guid id)
        {
            return db.Courses.Count(e => e.id == id) > 0;
        }
    }
}