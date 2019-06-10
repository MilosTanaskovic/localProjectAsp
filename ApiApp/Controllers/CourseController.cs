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


        public CourseController(IGetCoursesCommand getCommandCourses, IGetCourseCommand getCommandCourse, IDeleteCourseCommand delCommandCourse, IEditCourseCommand editCommandCourse)
        {
            _getCommandCourses = getCommandCourses;
            _getCommandCourse = getCommandCourse;
            _delCommandCourse = delCommandCourse;
            _editCommandCourse = editCommandCourse;
        }

        // GET: api/Course
        [HttpGet]
        public IActionResult Get([FromQuery]CourseSearchQuery search)
        {
            var resultCourses = _getCommandCourses.Execute(search);
            return Ok(resultCourses); //200
        }

        // GET: api/course/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
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
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/course/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateCourseDto dto)
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
            catch(Exception ex)
            {
                return StatusCode(500, "error");
            }
        }

        // DELETE: api/course/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
