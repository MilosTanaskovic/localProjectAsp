using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLayer.Commands;
using ApplicationLayer.SearchQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private IGetTeachersCommand _getCommandTeachers;
        private IGetTeacherCommand _getCommandTeacher;
        private IDeleteTeacherCommand _delCommandTeacher;
        
       
        public TeacherController(IGetTeachersCommand getCommandTeachers, IGetTeacherCommand getCommandTeacher, IDeleteTeacherCommand delCommandTeacher)
        {
            _getCommandTeachers = getCommandTeachers;
            _getCommandTeacher = getCommandTeacher;
            _delCommandTeacher = delCommandTeacher;
        }

        // GET: api/Teacher
        [HttpGet]
        public IActionResult Get([FromQuery]TeacherSearchQuery search)
        {
            var resultTeachers = _getCommandTeachers.Execute(search);
            return Ok(resultTeachers); //200
        }

        // GET: api/Teacher/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var resultTeacher = _getCommandTeacher.Execute(id);
                return Ok(resultTeacher);  //200
            }
            catch
            {
                return NotFound(); //404
            }
        }

        // POST: api/Teacher
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Teacher/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _delCommandTeacher.Execute(id);
                return Ok(); //200
            }
            catch
            {
                return NotFound(); //404
            }
        }
    }
}
