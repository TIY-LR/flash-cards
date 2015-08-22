using System.Collections.Generic;

namespace FlashCards.web.Models
{
    public class CardSetVM
    {
        public List<Card> cards { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}