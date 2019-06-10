using ApplicationLayer.Commands;
using ApplicationLayer.DTO;
using ApplicationLayer.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfGetCourseCommand : BaseEfCommand, IGetCourseCommand
    {
        public EfGetCourseCommand(AspProjContext context) : base(context)
        {

        }
        public CourseDto Execute(int request)
        {
            var getCourse = _context.Courses.Find(request);

            if (getCourse == null)
                throw new EntityNotFoundException();

            return new CourseDto
            {
                Id = getCourse.Id,
                CourseName = getCourse.CourseName,
                Description = getCourse.Description,
                Location = getCourse.Location
            };
        }
    }
}
