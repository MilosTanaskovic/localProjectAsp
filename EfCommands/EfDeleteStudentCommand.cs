using ApplicationLayer.Commands;
using ApplicationLayer.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteStudentCommand : BaseEfCommand, IDeleteStudentCommand
    {
        public EfDeleteStudentCommand(AspProjContext context) : base(context)
        {

        }
        public void Execute(int request)
        {
            var delStd = _context.Students.Find(request);

            if (delStd == null)
                throw new EntityNotFoundException("Student");

            _context.Students.Remove(delStd);

            _context.SaveChanges();
        }
    }
}
