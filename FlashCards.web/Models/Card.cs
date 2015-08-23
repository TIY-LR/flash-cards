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
        public  object Courses { get; set; }
    }

    public class RootObjectCourse
    {
        public object Course { get; set; }
    }

    public class Course
    {
        public int Id { get; set; }
        public virtual List<CardSet> CardSets { get; set; }
        public string Name { get; set; }
    }

    public class RootObjectCardSets
    {
        public object CardSets { get; set; }
    }

    public class RootObjectCardSet
    {
        public object CardSet { get; set; }
    }

    public class RootObjectCard
    {
        public object Card { get; set; }
    }

    public class CardSet
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Card> Cards { get; set; } 
    }

    public class Card
    {
        public int Id { get; set; }
        public string FrontText { get; set; }
        public string BackText { get; set; }
        public CardSet CardSet { get; set; }
       }
}
