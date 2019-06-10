using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationLayer.DTO
{
    public class TeacherDto
    {
        [Required(ErrorMessage = "This filed is required!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "This filed is required!")]
        public string TFirstName { get; set; }

        public string TLastName { get; set; }

        public string Description { get; set; }

        public string Nationality { get; set; }

        public IEnumerable<string> CourseName { get; set; }
    }
}
