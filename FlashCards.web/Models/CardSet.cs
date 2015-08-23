using System.Collections.Generic;

namespace FlashCards.web.Models
{
    public class CardSet
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Card> Cards { get; set; }
    }

    public class CardSetVM
    {
        public string Name { get; set; }
        public int Course { get; set; }
    }
}