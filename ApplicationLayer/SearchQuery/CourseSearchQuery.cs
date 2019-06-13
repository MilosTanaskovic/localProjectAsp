using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.SearchQuery
{
    public class CourseSearchQuery
    {
        public string CourseName { get; set; }
        public int PerPage { get; set; } = 1;
        public int PageNumber { get; set; } = 1;
    }
}
