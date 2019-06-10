using ApplicationLayer.Commands;
using ApplicationLayer.DTO;
using ApplicationLayer.SearchQuery;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetTeachersCommand : BaseEfCommand, IGetTeachersCommand
    {
        public EfGetTeachersCommand(AspProjContext context) : base(context)
        {

        }
        public IEnumerable<TeacherDto> Execute(TeacherSearchQuery request)
        {
            var getTeachers = _context.Teachers.AsQueryable();

            if (request.Keyword != null)
            {
                getTeachers = getTeachers.Where(t => t.TFirstName
                .ToLower()
                .Contains(request.Keyword.ToLower()));
            }

            if (request.OnlyActive.HasValue)
            {
                getTeachers = getTeachers.Where(std => std.IsDeleted != request.OnlyActive);
            }

            return getTeachers
                .Include(t => t.Courses)
                .Select(t => new TeacherDto
                {
                    Id = t.Id,
                    TFirstName = t.TFirstName,
                    TLastName = t.TLastName,
                    Description = t.Description,
                    Nationality = t.Nationality,
                    CourseName = t.Courses.Select(c => c.CourseName)
                });
        }
    }
}
