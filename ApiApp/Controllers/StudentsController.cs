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
        private IEditStudentCommand _editCommandStd;

        public StudentsController(IGetStudentsCommand getCommandStds, IGetStudentCommand getCommandStd, IAddStudentCommand addCommandStd, IDeleteStudentCommand delCommandStd, IEditStudentCommand editCommandStd)
        {
            _getCommandStds = getCommandStds;
            _getCommandStd = getCommandStd;
            _addCommandStd = addCommandStd;
            _delCommandStd = delCommandStd;
            _editCommandStd = editCommandStd;
        }


        /// <summary>
        /// Returns all Students that match provided query
        /// </summary> 
        /// <remarks>
        /// Sample request:
        ///
        ///     GET students
        ///     {
        ///        "id": 1,
        ///        "isDeleted" : false
        ///        "StudenName": "Nikola",
        ///        "StudyYear": 3,
        ///        "NumberIndex" : "6543324",
        ///        "Nationality" : "Srpsko",
        ///        "BirthDate" : "14121994",
        ///        
        ///     }
        ///
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created StudentDto</returns>
        /// <response code="201">Returns the Ok</response>        
        // GET api/students
        [HttpGet]
        [ProducesResponseType(200)]       
        public ActionResult<IEnumerable<StudentDto>> Get([FromQuery]StudentSearchQuery query)
        {
            return Ok(_getCommandStds.Execute(query)); //200
        }

        // GET api/student/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<StudentDto>> Get(int id)
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
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<CreateStudentDto>> Post([FromBody] CreateStudentDto dto)
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
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<CreateStudentDto>> Put(int id, [FromBody] CreateStudentDto dto)
        {
            dto.Id = id;
            try
            {
                _editCommandStd.Execute(dto);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Student doesn't exist.")
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

        // DELETE api/student/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<StudentDto>> Delete(int id)
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
            catch (Exception)
            {
                return StatusCode(500, "It's not working"); //500
            }
            
            
        }
    }
}
