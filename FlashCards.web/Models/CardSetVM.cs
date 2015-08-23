using System.Collections.Generic;

namespace FlashCards.web.Models
{
    public class CardSetEmberWrapper
    {
        public CardSetVM CardSet { get; set; }
    }
    public class CardSetVM
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
    }
}