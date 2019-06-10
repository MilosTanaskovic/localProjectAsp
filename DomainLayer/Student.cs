using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Student : BaseEntity
    {
        public string StudentName { get; set; }
        public int StudyYear { get; set; }
        public int NumberIndex { get; set; }
        public int NumberPhone { get; set; }
        public string Natioanality { get; set; }
        public int BirthDate { get; set; }

        public int StandardId { get; set; }  // forign key

        public Standard StandardStudent { get; set; }  // ref
        public StudentAddress StudentAddress { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
