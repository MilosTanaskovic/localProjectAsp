using ApplicationLayer.Commands;
using ApplicationLayer.DTO;
using ApplicationLayer.SearchQuery;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetStudentsCommand : BaseEfCommand, IGetStudentsCommand
    {

        public EfGetStudentsCommand(AspProjContext context) : base(context)
        {
            
        }

        public IEnumerable<StudentDto> Execute(StudentSearchQuery request)
        {
            var getStudents = _context.Students.AsQueryable();

            if(request.Keyword != null)
            {
                getStudents = getStudents.Where(std => std.StudentName
                .ToLower()
                .Contains(request.Keyword.ToLower()));
            }

            if (request.OnlyActive.HasValue)
            {
                getStudents = getStudents.Where(std => std.IsDeleted != request.OnlyActive);
            }

            return getStudents.Select(std => new StudentDto
            {
                Id = std.Id,
                StudentName = std.StudentName,
                StudyYear = std.StudyYear,
                NumberIndex = std.NumberIndex
            });
        }
    }
}
