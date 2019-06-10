using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.SearchQuery
{
    public class TeacherSearchQuery
    {
        public string Keyword { get; set; }
        public string TFirstName { get; set; }
        public string TLastName { get; set; }
        public bool? OnlyActive { get; set; }
    }
}
