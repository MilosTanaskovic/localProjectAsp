using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class StudentAddress : BaseEntity
    {
        public string Address { get; set; }
        public string City { get; set; }
        public bool State { get; set; }

        public int StudentId { get; set; }  // for key , must be unique
                                              // One-to-One relationships with Student Entity

        public Student Student { get; set; }  // ref
    }
}
