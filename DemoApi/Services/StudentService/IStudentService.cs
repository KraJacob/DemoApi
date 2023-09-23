using DemoApi.DTOs.Requests;
using DemoApi.DTOs.Responses;

namespace DemoApi.Services.StudentService
{
    public interface IStudentService
    {
        BaseResponse CreateStudentRequest(CreateStudentRequest request);
        BaseResponse StudentList();
        BaseResponse GetStudentById(long id);
        BaseResponse UpdateStudentById(long id, UpdateStudentRequest request);
        BaseResponse DeleteStudentById(long id);
    }
}
