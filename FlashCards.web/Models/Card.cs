using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace FlashCards.web.Models
{
    public class RootObjectCourses
    {
        public List<Course> Courses { get; set; }
    }

    public class Course
    {
        public int Id { get; set; }
        public virtual List<CardSet> CardSets { get; set; }
        public string Name { get; set; }
    }

    public class CardSet
    {
        public int id { get; set; }
        public Course Course { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Card> Cards { get; set; } 
    }

    public class Card
    {
        public int id { get; set; }
        public string FrontText { get; set; }
        public string BackText { get; set; }
        public CardSet CardSet { get; set; }
       
    }
}
