using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLayer.Commands;
using ApplicationLayer.DTO;
using ApplicationLayer.Exceptions;
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
        private IAddTeacherCommand _addCommandTeacher;
        private IEditTeacherCommand _editCommandTeacher;
 
        public TeacherController(IGetTeachersCommand getCommandTeachers, IGetTeacherCommand getCommandTeacher, IDeleteTeacherCommand delCommandTeacher, IAddTeacherCommand addCommandTeacher, IEditTeacherCommand editCommandTeacher)
        {
            _getCommandTeachers = getCommandTeachers;
            _getCommandTeacher = getCommandTeacher;
            _delCommandTeacher = delCommandTeacher;
            _addCommandTeacher = addCommandTeacher;
            _editCommandTeacher = editCommandTeacher;
        }

        // GET: api/Teacher
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<TeacherDto>> Get([FromQuery]TeacherSearchQuery search)
        {
            var resultTeachers = _getCommandTeachers.Execute(search);
            return Ok(resultTeachers); //200
        }

        // GET: api/Teacher/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<TeacherDto>> Get(int id)
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
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<CreateTeacherDto>> Post([FromBody] CreateTeacherDto dto)
        {
            try
            {
                _addCommandTeacher.Execute(dto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (EntityNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT: api/Teacher/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<CreateTeacherDto>> Put(int id, [FromBody] CreateTeacherDto dto)
        {
            dto.Id = id;
            try
            {
                _editCommandTeacher.Execute(dto);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Teacher doesn't exist.")
                {
                    return NotFound(e.Message);
                }

                return UnprocessableEntity(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "error");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<TeacherDto>> Delete(int id)
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
