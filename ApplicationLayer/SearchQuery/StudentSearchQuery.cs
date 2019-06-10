using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.SearchQuery
{
    public class StudentSearchQuery
    {
        public string Keyword { get; set; }
        public int NumberIndex { get; set; }
        public bool? OnlyActive { get; set; }
    }
}
