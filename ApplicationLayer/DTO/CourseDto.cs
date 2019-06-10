using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationLayer.DTO
{
    public class CourseDto
    {
        [Required(ErrorMessage = "This filed is required!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "This filed is required!")]
        public string CourseName { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public IEnumerable<string> StudentName { get; set; }
    }
}
