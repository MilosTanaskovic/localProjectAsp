using ApplicationLayer.Commands;
using ApplicationLayer.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteTeacherCommand : BaseEfCommand, IDeleteTeacherCommand
    {
        public EfDeleteTeacherCommand(AspProjContext context) : base(context)
        {

        }
        public void Execute(int request)
        {
            var delTeacher = _context.Teachers.Find(request);

            if (delTeacher == null)
                throw new EntityNotFoundException("Teacher");

            _context.Teachers.Remove(delTeacher);

            _context.SaveChanges();
        }
    }
}
