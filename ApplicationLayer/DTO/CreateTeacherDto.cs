using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.DTO
{
    public class CreateTeacherDto
    {
        public int Id { get; set; }
        public string TFirstName { get; set; }
        public string TLastName { get; set; }
        public string Description { get; set; }
        public string Nationality { get; set; }

        public int StandardId { get; set; }
    }
}
