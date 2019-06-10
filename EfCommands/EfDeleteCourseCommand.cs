using ApplicationLayer.Commands;
using ApplicationLayer.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteCourseCommand : BaseEfCommand, IDeleteCourseCommand
    {

        public EfDeleteCourseCommand(AspProjContext context) : base(context)
        {
            
        }

        public void Execute(int request)
        {
            var delCourse = _context.Courses.Find(request);

            if (delCourse == null)
                throw new EntityNotFoundException("Course");

            _context.Courses.Remove(delCourse);

            _context.SaveChanges();
        }
    }
}
