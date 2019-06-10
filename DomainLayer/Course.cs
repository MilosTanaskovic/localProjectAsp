using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Course : BaseEntity
    {
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        //public decimal Price { get; set; }
        //public int Count { get; set; }

        public int TeacherId { get; set; } // foriegn key

        public Teacher Teacher { get; set; }  // ref
        public ICollection<StudentCourse> CourseStudents { get; set; }
    }
}
