using ApplicationLayer.Commands;
using ApplicationLayer.DTO;
using ApplicationLayer.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetTeacherCommand : BaseEfCommand, IGetTeacherCommand
    {
        public EfGetTeacherCommand(AspProjContext context) : base(context)
        {

        }
        public TeacherDto Execute(int request)
        {
            var getTeacher = _context.Teachers.Find(request);

            if (getTeacher == null)
                throw new EntityNotFoundException();

            return new TeacherDto
            {
                Id = getTeacher.Id,
                TFirstName = getTeacher.TFirstName,
                TLastName = getTeacher.TLastName,
                Description = getTeacher.Description,
                Nationality = getTeacher.Nationality,
                //CourseName = getTeacher.Courses.Select(c => c.CourseName)
                    
            };
        }
    }
}
