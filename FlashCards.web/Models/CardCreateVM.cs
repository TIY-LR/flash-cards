namespace FlashCards.web.Models
{
    public class CardCreateVM
    {
        public int CardSetId { get; set; }
        public string FrontText { get; set; }
        public string BackText { get; set; }
        public int CardId { get; set; }
    }
}