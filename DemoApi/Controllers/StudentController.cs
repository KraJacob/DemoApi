using DemoApi.DTOs.Requests;
using DemoApi.DTOs.Responses;
using DemoApi.Services.StudentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("save")]
        public BaseResponse CreatStudent(CreateStudentRequest request)
        {
            return _studentService.CreateStudentRequest(request);
        }

        [HttpGet("list")]
        public BaseResponse StudentList()
        {
            return _studentService.StudentList();
        }

        [HttpGet("{id}")]
        public BaseResponse GetStudentByID(int id)
        {
            return _studentService.GetStudentById(id);
        }

        [HttpPut("{id}")]
        public BaseResponse UpdateStudentByID(long id, UpdateStudentRequest request)
        {
            return _studentService.UpdateStudentById(id, request);
        }

        [HttpDelete("{id}")]
        public BaseResponse DeleteStudentByID(long id) 
        {
            return _studentService.DeleteStudentById(id);
        }
    }
}
