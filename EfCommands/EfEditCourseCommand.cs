using ApplicationLayer.Commands;
using ApplicationLayer.DTO;
using ApplicationLayer.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfEditCourseCommand : BaseEfCommand, IEditCourseCommand
    {
        public EfEditCourseCommand(AspProjContext context) : base(context)
        {

        }

        public void Execute(CreateCourseDto request)
        {
            var editCourse = _context.Courses.Find(request);

            if (editCourse == null)
            {
                throw new EntityNotFoundException("Course");
            }

            if(!_context.Teachers.Any(t => t.Id == request.TeacherId))
            {
                throw new EntityNotFoundException("Teacher");
            }

            //editCourse.Id = request.Id;
            editCourse.CourseName = request.CourseName;
            editCourse.Description = request.Description;
            editCourse.Location = request.Location;
            editCourse.TeacherId = request.TeacherId;
            editCourse.CreatedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
