using System.Collections.Generic;

namespace FlashCards.web.Models
{
    public class Course
    {
        public int Id { get; set; }
        public virtual List<CardSet> CardSets { get; set; }
        public string Name { get; set; }
    }
    public class CourseVM
    {
        public string Name { get; set; }
    }
}