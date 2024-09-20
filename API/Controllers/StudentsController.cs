using Application.Command;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudent([FromBody]CreateStudent.CreateStudentCommand command)
        {
            var student = await _mediator.Send(command);
            return Ok(student);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            var getStudent = await _mediator.Send(new GetStudent.GetStudentQuery(id));
            return Ok(getStudent);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudent([FromQuery] GetAllStudents.GetAllStudentQueries request) 
        {
            var getStudents = await _mediator.Send(request);
            return Ok(getStudents);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudent.UpdateStudentCommand command)
        {
            var student = await _mediator.Send(command);
            return Ok(student);
        }
    }
}
