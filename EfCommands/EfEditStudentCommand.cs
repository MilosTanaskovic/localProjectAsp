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

        public void Execute(CreateStudentDto request)
        {
            var editStd = _context.Students.Find(request.Id);

            if (editStd == null)
                throw new EntityNotFoundException();

            if(editStd.StudentName != request.StudentName)
            {
                if(_context.Students.Any(s => s.StudentName == request.StudentName/* && s.NumberIndex == request.NumberIndex*/))
                {
                    throw new EntityNotFoundException();
                }

                editStd.StudentName = request.StudentName;
                editStd.NumberIndex = request.NumberIndex;
                editStd.StudyYear = request.StudyYear;
                editStd.NumberPhone = request.NumberPhone;
                editStd.Natioanality = request.Natioanality;
                editStd.BirthDate = request.BirthDate;
                editStd.StandardId = request.StandardId;


                _context.SaveChanges();
            }
        }
    }
}
