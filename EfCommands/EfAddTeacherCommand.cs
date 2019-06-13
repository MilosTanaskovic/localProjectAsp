using ApplicationLayer.Commands;
using ApplicationLayer.DTO;
using ApplicationLayer.Exceptions;
using DomainLayer;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfAddTeacherCommand : BaseEfCommand, IAddTeacherCommand
    {
        public EfAddTeacherCommand(AspProjContext context): base(context)
        {

        }
        public void Execute(CreateTeacherDto request)
        {
            if (_context.Teachers.Any(t => t.TFirstName == request.TFirstName && t.TLastName == request.TLastName ))
            {
                throw new EntityNotFoundException();
            }

            if (!_context.Standards.Any(s => s.Id == request.StandardId))
            {
                throw new EntityNotFoundException("Standard");
                // Message -> Standard doesn't exist
            }

            _context.Teachers.Add(new Teacher
            {
                //Id = request.Id,
                TFirstName = request.TFirstName,
                TLastName = request.TLastName,
                Description = request.Description,
                Nationality = request.Nationality,
                CreatedAt = DateTime.Now,
                StandardId = request.StandardId
            });

            _context.SaveChanges();
        }
    }
}
