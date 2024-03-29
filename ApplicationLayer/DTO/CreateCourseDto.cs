﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationLayer.DTO
{
    public class CreateCourseDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This filed is required!")]
        [RegularExpression("^[A-Z][a-z]{2,20}$", ErrorMessage = "A name isn't correct. Please, try again!")]
        public string CourseName { get; set; }
        [RegularExpression("^[A-Z][a-z]{5,100}$", ErrorMessage = "The description isn't correct. Please, try again!")]
        public string Description { get; set; }

        public string Location { get; set; }

        public int TeacherId { get; set; }
    }
}
