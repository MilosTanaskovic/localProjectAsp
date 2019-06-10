using ApplicationLayer.Commands;
using ApplicationLayer.DTO;
using ApplicationLayer.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfGetStudentCommand : BaseEfCommand, IGetStudentCommand
    {
        public EfGetStudentCommand(AspProjContext context) : base(context)
        {

        }
        public StudentDto Execute(int request)
        {
            var getStd = _context.Students.Find(request);

            if (getStd == null)
                throw new EntityNotFoundException();

            return new StudentDto
            {
                Id = getStd.Id,
                StudentName = getStd.StudentName,
                StudyYear = getStd.StudyYear,
                NumberIndex = getStd.NumberIndex
            };
        }
    }
}
