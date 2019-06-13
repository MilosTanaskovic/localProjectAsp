using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Commands
{
    public interface IAddTeacherCommand : ICommand<CreateTeacherDto>
    {
    }
}
