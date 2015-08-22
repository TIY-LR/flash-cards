using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace FlashCards.web.Models
{
    public class ResponseData
    {

    }

    public class Course
    {
        public Guid id { get; set; }
        public virtual List<cardSet> cardSets { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class CourseVM
    {
        public string name { get; set; }
        public string description { get; set; }
    }
    public class cardSet
    {
        public Guid id { get; set; }
        public virtual List<Card> cards { get; set; }

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
