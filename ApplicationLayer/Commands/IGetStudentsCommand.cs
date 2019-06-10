using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using ApplicationLayer.SearchQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Commands
{
    public interface IGetStudentsCommand : ICommand<StudentSearchQuery, IEnumerable<StudentDto>>
    {
    }
}
