using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLayer.Commands;
using ApplicationLayer.DTO;
using ApplicationLayer.SearchQuery;
using Microsoft.AspNetCore.Mvc;
using ApplicationLayer.Exceptions;

namespace ApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IGetStudentsCommand _getCommandStds;
        private IGetStudentCommand _getCommandStd;
        private IAddStudentCommand _addCommandStd;
        private IDeleteStudentCommand _delCommandStd;

        public StudentsController(IGetStudentsCommand getCommandStds, IGetStudentCommand getCommandStd, IAddStudentCommand addCommandStd, IDeleteStudentCommand delCommandStd)
        {
            _getCommandStds = getCommandStds;
            _getCommandStd = getCommandStd;
            _addCommandStd = addCommandStd;
            _delCommandStd = delCommandStd;
        }

        // GET api/students
        [HttpGet]
        public IActionResult Get([FromQuery]StudentSearchQuery query)
        {
            return Ok(_getCommandStds.Execute(query)); //200
        }

        // GET api/student/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var resultStd = _getCommandStd.Execute(id);
                return Ok(resultStd);  // 200
            }
            catch
            {
                return NotFound(); // 404
            }

            
        }

        // POST api/student
        [HttpPost]
        public IActionResult Post([FromBody] StudentDto dto)
        {
            try
            {
                _addCommandStd.Execute(dto);
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
            
           // return Created("url", null);  // 201
        }

        // PUT api/students/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StudentDto dto)
        {

        }

        // DELETE api/student/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _delCommandStd.Execute(id);
                return NoContent();  //204
            }
            catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);  //404
            }
            catch (Exception ex)
            {
                return StatusCode(500, "It's not working"); //500
            }
            
            
        }
    }
}
