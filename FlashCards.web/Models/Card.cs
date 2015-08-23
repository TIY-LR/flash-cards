using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace FlashCards.web.Models
{
    

    public class Course
    {
        public int Id { get; set; }
        public virtual List<CardSet> CardSets { get; set; }
        public string Name { get; set; }
    }

    public class EmberWrapper
    {
        public ICollection<CourseVM> Courses { get; set; }

        public CourseVM Course { get; set; }

        public ICollection<CardSetVM> CardSets { get; set; }

        public CardSet CardSet { get; set; }

        public CardVM Card { get; set; }

        public ICollection<CardVM> Cards { get; set; }
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
