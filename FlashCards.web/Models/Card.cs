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
        public Guid id { get; set; }
        public virtual List<CardSet> CardSets { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class CourseVM
    {
        public List<CardSet> cards { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
    public class CardSet
    {
        public Guid id { get; set; }
        public Course Course { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class CardSetVM
    {
        public List<Card> cards { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    [JsonObject(Title = "card")]
    public class Card
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string frontText { get; set; }
        public string backText { get; set; }
        public CardSet CardSet { get; set; }
        public Card(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public Card() { }
    }

    public class CardCreateVM
    {
        public string name { get; set; }
        public string description { get; set; }
    }


}
