using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public abstract class BaseEfCommand
    {
        protected  AspProjContext _context { get; }

        protected BaseEfCommand(AspProjContext context)
        {
            _context = context;
        }
    }
}
