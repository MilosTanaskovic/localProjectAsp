using ApplicationLayer.Commands;
using ApplicationLayer.DTO;
using ApplicationLayer.Responses;
using ApplicationLayer.SearchQuery;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetCoursesCommand : BaseEfCommand, IGetCoursesCommand
    {     

        public EfGetCoursesCommand(AspProjContext context) : base(context)
        {

        }
        

        public PagedResponse<CourseDto> Execute(CourseSearchQuery request)
        {
            var getCourse = _context.Courses.AsQueryable();

            if(request.CourseName != null)
            {
                var keyword = request.CourseName.ToLower();

                getCourse = getCourse.Where(c => c.CourseName
                .ToLower()
                .Contains(keyword));
            }


            var totalCount = getCourse.Count();

            var result = getCourse
                .Include(c => c.CourseStudents)
                .ThenInclude(cs => cs.Course).Skip((request.PageNumber - 1)* request.PerPage).Take(request.PerPage);
                

            
            var pageCount = (int)Math.Ceiling((double)totalCount/request.PerPage);

            var response = new PagedResponse<CourseDto>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PagesCount = pageCount,
                Data = getCourse.Select(c => new CourseDto
                {
                    Id = c.Id,
                    CourseName = c.CourseName,
                    Description = c.Description,
                    Location = c.Location,
                    StudentName = c.CourseStudents.Select(cs => cs.Student.StudentName)
                })
            };

            return response;
                
        }
    }
}
