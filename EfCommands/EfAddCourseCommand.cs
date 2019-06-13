using ApplicationLayer.Commands;
using ApplicationLayer.DTO;
using ApplicationLayer.Exceptions;
using DomainLayer;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfAddCourseCommand : BaseEfCommand, IAddCourseCommand
    {
        public EfAddCourseCommand(AspProjContext context): base(context)
        {

        }
        public void Execute(CreateCourseDto request)
        {
            if (_context.Courses.Any(c => c.CourseName == request.CourseName && c.Location == request.Location ))
            {
                throw new EntityNotFoundException();
            }

            if (!_context.Teachers.Any(t => t.Id == request.TeacherId))
            {
                throw new EntityNotFoundException("Teachers");
                // Message -> Teacher doesn't exist
            }

            _context.Courses.Add(new Course
            {
                CourseName = request.CourseName,
                Description = request.Description,
                Location = request.Location,
                CreatedAt = DateTime.Now,
                TeacherId = request.TeacherId
            });

            _context.SaveChanges();
        }
    }
}
