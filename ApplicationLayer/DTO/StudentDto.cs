using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationLayer.DTO
{
    public class StudentDto
    {

        //[Required(ErrorMessage = "This filed is required! Please, try again!")]
        public int Id { get; set; }
       
        [Required(ErrorMessage = "This filed is required! Please, try again!")]
        [RegularExpression("^[A-Z][a-z]{2,20}$", ErrorMessage = "The name isn't correct. Please, try again!")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "This filed is required!")]
        [RegularExpression("^[0-9]{3,8}$", ErrorMessage = "The index number isn't correct. Please, try again!")]
        public int NumberIndex { get; set; }

        public int StudyYear { get; set; }

        public int NumberPhone { get; set; }
        public string Natioanality { get; set; }
        public int BirthDate { get; set; }

        [Required(ErrorMessage = "This filed is required! Please, try again!")]
        public int StandardId { get; set; }


    }
}
