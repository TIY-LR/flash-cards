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

    public class course
    {
        public Guid id { get; set; }
        public virtual List<cardSet> cardSets { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class cardSet
    {
        public Guid id { get; set; }
        public virtual List<card> cards { get; set; }

        public string name { get; set; }
        public string description { get; set; }
    }

    public class card
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string frontText { get; set; }
        public string backText { get; set; }
    }


}
