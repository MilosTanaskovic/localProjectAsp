using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using ApplicationLayer.SearchQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Commands
{
    public interface IGetTeachersCommand : ICommand<TeacherSearchQuery, IEnumerable<TeacherDto>>
    {
    }
}
