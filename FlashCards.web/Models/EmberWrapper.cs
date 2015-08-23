using System.Collections.Generic;

namespace FlashCards.web.Models
{
    public class EmberWrapper
    {
        public ICollection<CourseVM> Courses { get; set; }
        public CourseVM Course { get; set; }
        public ICollection<CardSetVM> CardSets { get; set; }
        public CardSetVM CardSet { get; set; }
        public CardVM Card { get; set; }
        public ICollection<CardVM> Cards { get; set; }
    }
}