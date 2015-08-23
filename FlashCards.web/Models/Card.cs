namespace FlashCards.web.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string FrontText { get; set; }
        public string BackText { get; set; }
        public CardSet CardSet { get; set; }
    }

    public class CardVM
    {
        public string FrontText { get; set; }
        public string BackText { get; set; }
        public int CardSet { get; set; }
    }
}