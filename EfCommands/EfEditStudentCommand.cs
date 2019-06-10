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
    public class EfEditStudentCommand : BaseEfCommand, IEditStudentCommand
    {
        public EfEditStudentCommand(AspProjContext context) : base(context)
        {

        }

        public void Execute(StudentDto request)
        {
            var editStd = _context.Students.Find(request.Id);

            if (editStd == null)
                throw new EntityNotFoundException();

            if(editStd.StudentName != request.StudentName)
            {
                if(_context.Students.Any(s => s.StudentName == request.StudentName && s.NumberIndex == request.NumberIndex))
                {
                    throw new EntityNotFoundException();
                }

                editStd.StudentName = request.StudentName;

                _context.SaveChanges();
            }
        }
    }
}
