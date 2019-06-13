using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Responses;
using ApplicationLayer.SearchQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Commands
{
    public interface IGetCoursesCommand : ICommand<CourseSearchQuery, PagedResponse<CourseDto>>
    {
        //IEnumerable<CourseDto> Execute(CourseSearchQuery request);
    }
}
