using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlashCards.web.Models
{
    public class CardEmberWrapper
    {
        public Card Card { get; set; }
    }
    public class CardVM
    {
        public string FrontText { get; set; }
        public string  BackText { get; set; }
        public int CardSetId { get; set; }
    }
}
