using System.Collections.Generic;

namespace FlashCards.web.Models
{
    public class CourseVM
    {
        public List<CardSet> Cards { get; set; }
        public string Name { get; set; }
    }
}