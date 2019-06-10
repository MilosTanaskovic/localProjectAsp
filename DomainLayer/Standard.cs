using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Standard : BaseEntity
    {
        public string StandardName { get; set; }
        public string Description { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
