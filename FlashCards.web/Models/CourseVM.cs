using System.Collections.Generic;

namespace FlashCards.web.Models
{
    public class EmberWrapper
    {
        public CourseVM course { get; set; }
    }
    public class CourseVM
    {
       public string Name { get; set; }
    }
}