using ApplicationLayer.Commands;
using ApplicationLayer.DTO;
using ApplicationLayer.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using DomainLayer;

namespace EfCommands
{
    public class EfAddStudentCommand : BaseEfCommand, IAddStudentCommand
    {
        public EfAddStudentCommand (AspProjContext context) : base(context)
        {

        }
        public void Execute(StudentDto request)
        {
            if (_context.Students.Any(std => std.StudentName == request.StudentName && std.NumberIndex == request.NumberIndex && std.StudyYear > 12))
            {
                throw new EntityNotFoundException();
            }

            if (!_context.Standards.Any(s => s.Id == request.StandardId))
            {
                throw new EntityNotFoundException("Standard");
                // Message -> Student doesn't exist
            }

            _context.Students.Add(new Student
            {
                StudentName = request.StudentName,
                StudyYear = request.StudyYear,
                NumberIndex = request.NumberIndex,
                NumberPhone = request.NumberPhone,
                Natioanality = null,
                StandardId = request.StandardId,
                CreatedAt = DateTime.Now
            });

            _context.SaveChanges();
        }
    }
}
