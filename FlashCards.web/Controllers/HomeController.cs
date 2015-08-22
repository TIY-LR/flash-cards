using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlashCards.web.Models;
using Microsoft.AspNet.Identity;

namespace FlashCards.web.Controllers
{
    public class HomeController : Controller
    {
    
        public ActionResult Index()
        { 
            ApplicationDbContext db = new ApplicationDbContext();
            db.SaveChanges();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
