using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace FlashCards.web.Models
{
    public class ResponseData
    {

    }

    public class Course
    {
        public Guid id { get; set; }
        public ApplicationUser creator { get; set; }
        public DateTime createdOn { get; set; }
        public List<CardSet> cardSets { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        
    }

    public class CardSet
    {
        public Guid id { get; set; }
        public List<Card> cards { get; set; }
        public ApplicationUser creator { get; set; }

        public string name { get; set; }
        public string description { get; set; }
    }

    public class Card
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        //tentative
        public Guid cardSetId { get; set; }
        public Guid creatorId { get; set; }
    }


}
