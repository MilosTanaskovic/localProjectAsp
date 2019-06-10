using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Teacher : BaseEntity
    {
        public string TFirstName { get; set; }
        public string TLastName { get; set; }
        public string Description { get; set; }
        public string Nationality { get; set; }

        public int StandardId { get; set; }

        public Standard StandardTeacher { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
