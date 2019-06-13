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
    public class CourseController : ControllerBase
    {
        private readonly IGetCoursesCommand _getCommandCourses;
        private readonly IGetCourseCommand _getCommandCourse;
        private readonly IDeleteCourseCommand _delCommandCourse;
        private readonly IEditCourseCommand _editCommandCourse;
        private readonly IAddCourseCommand _addCommandCourse;
        

        public CourseController(IGetCoursesCommand getCommandCourses, IGetCourseCommand getCommandCourse, IDeleteCourseCommand delCommandCourse, IEditCourseCommand editCommandCourse, IAddCourseCommand addCommandCourse)
        {
            _getCommandCourses = getCommandCourses;
            _getCommandCourse = getCommandCourse;
            _delCommandCourse = delCommandCourse;
            _editCommandCourse = editCommandCourse;
            _addCommandCourse = addCommandCourse;
        }

        // GET: api/Course
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<CourseDto>> Get([FromQuery]CourseSearchQuery search)
        {
            var resultCourses = _getCommandCourses.Execute(search);
            return Ok(resultCourses); //200
        }

        // GET: api/course/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<CourseDto>> Get(int id)
        {
            try
            {
                var resultCourse = _getCommandCourse.Execute(id);
                return Ok(resultCourse); //200
            }
            catch
            {
                return NotFound(); //404
            }
        }

        // POST: api/course
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<CreateCourseDto>> Post([FromBody] CreateCourseDto dto)
        {
            try
            {
                _addCommandCourse.Execute(dto);
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

        // PUT: api/course/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<CreateCourseDto>> Put(int id, [FromBody] CreateCourseDto dto)
        {
            dto.Id = id;
            try
            {
                _editCommandCourse.Execute(dto);
                return NoContent();
            }
            catch(EntityNotFoundException e)
            {
                if(e.Message == "Course doesn't exist.")
                {
                    return NotFound(e.Message);
                }

                return UnprocessableEntity(e.Message);
            }
            catch(Exception)
            {
                return StatusCode(500, "error");
            }
        }

        // DELETE: api/course/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<CourseDto>> Delete(int id)
        {
            try
            {
                _delCommandCourse.Execute(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
