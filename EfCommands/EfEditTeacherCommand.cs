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
    public class EfEditTeacherCommand : BaseEfCommand, IEditTeacherCommand
    {
        public EfEditTeacherCommand(AspProjContext context) : base(context)
        {

        }
        public void Execute(CreateTeacherDto request)
        {
            var editT = _context.Teachers.Find(request.Id);

            if (editT == null)
                throw new EntityNotFoundException();

            if (editT.TFirstName != request.TFirstName)
            {
                if (_context.Teachers.Any(t => t.TFirstName == request.TFirstName && t.TLastName == request.TLastName))
                {
                    throw new EntityNotFoundException();
                }

                editT.TFirstName = request.TFirstName;
                editT.TLastName = request.TLastName;
                editT.Description = request.Description;
                editT.Nationality = request.Nationality;
                editT.StandardId = request.StandardId;


                _context.SaveChanges();
            }
        }
    }
}
