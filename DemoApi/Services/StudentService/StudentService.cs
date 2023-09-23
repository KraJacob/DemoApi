using DemoApi.DTOs;
using DemoApi.DTOs.Requests;
using DemoApi.DTOs.Responses;
using DemoApi.Models;

namespace DemoApi.Services.StudentService
{
    public class StudentService: IStudentService
    {
        private readonly ApplicationDBContext _dbContext;

        public StudentService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BaseResponse CreateStudentRequest(CreateStudentRequest request)
        {
            BaseResponse response;

            try
            {
                StudentModel student = new StudentModel();
                student.FirstName = request.FirstName;
                student.LastName = request.LastName;
                student.Address = request.Address;
                student.Eamil = request.Email;
                student.Phone = request.Phone;

                using (_dbContext)
                {
                    _dbContext.Add(student);
                    _dbContext.SaveChanges();
                }

                response = new BaseResponse { StatusCode = StatusCodes.Status201Created,
                                              Data = new { message = "Successfully created !"}
                };

                return response;

            }catch (Exception ex)
            {
                response = new BaseResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = new { message = "Internal server error : " + ex.Message}
                };

                return response;
            }
        }

        public BaseResponse DeleteStudentById(long id)
        {
            BaseResponse response;
            try {
                StudentModel student = _dbContext.Students.Where(s => s.Id == id).FirstOrDefault();
                if (student != null)
                {
                    _dbContext.Remove(student);
                    _dbContext.SaveChanges();
                    response = new BaseResponse { StatusCode = StatusCodes.Status200OK, Data = new { message = "Successfully deleted" } };
                }
                else
                {
                    response = new BaseResponse { StatusCode = StatusCodes.Status404NotFound, Data = new { message = "Student not found" } };
                }

                return response;

            }catch (Exception ex) {
                response = new BaseResponse { StatusCode= StatusCodes.Status500InternalServerError,
                    Data = new { message = "Internale server error : " + ex.Message}
                };

                return response;
            }
        }

        public BaseResponse GetStudentById(long id)
        {
           BaseResponse response;
            try
            {

                StudentDTO studentDTO = new StudentDTO();

                using (_dbContext)
                {
                    StudentModel student = _dbContext.Students.Where(s => s.Id == id).FirstOrDefault();

                    if (student != null)
                    {
                        studentDTO.FirstName = student.FirstName;
                        studentDTO.LastName = student.LastName;
                        studentDTO.Address = student.Address;
                        studentDTO.Email = student.Eamil;
                        studentDTO.Phone = student.Phone;

                        response = new BaseResponse { StatusCode = StatusCodes.Status200OK, Data = new { studentDTO } };
                    }
                    else
                    {
                        response = new BaseResponse { StatusCode = StatusCodes.Status404NotFound, Data = new { message = "Student not found" } };
                    }

                    return response;
                }
            }
            catch (Exception ex)
            {
                response = new BaseResponse { StatusCode = StatusCodes.Status500InternalServerError, Data = new { message = "Internal server error" + ex.Message } };
                return response;
            }
        }

        public BaseResponse StudentList()
        {
            BaseResponse response;
            List<StudentDTO> students = new List<StudentDTO>();

            try
            {
                using (_dbContext)
                {
                    _dbContext.Students.ToList().ForEach(student => students.Add(new StudentDTO
                    {
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Address = student.Address,
                        Phone = student.Phone,
                        Email = student.Eamil
                    }));
                }

                response = new BaseResponse
                {
                    StatusCode = StatusCodes.Status200OK,
                    Data = new { students }
                };

                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse {
                    StatusCode = StatusCodes.Status500InternalServerError, Data = new { message = "Internal server error : "+ex.Message}
                };

                return response;
            }
        }

        public BaseResponse UpdateStudentById(long id, UpdateStudentRequest request)
        {
            BaseResponse response;
            StudentDTO student;

            try
            {
                using (_dbContext)
                {
                    StudentModel studentModel = _dbContext.Students.Where(s => s.Id == id).FirstOrDefault();

                    if (studentModel != null)
                    {
                        studentModel.FirstName = request.FirstName;
                        studentModel.LastName = request.LastName;
                        studentModel.Address = request.Address;
                        studentModel.Phone = request.Phone;
                        studentModel.Eamil = request.Email;

                        _dbContext.SaveChanges();

                        response = new BaseResponse { StatusCode = StatusCodes.Status200OK, Data = new { studentModel } };
                    }
                    else
                    {
                        response = new BaseResponse { StatusCode = StatusCodes.Status404NotFound, Data = new { message = "Student not found" } };
                    }

                    return response;
                }

            }catch(Exception ex)
            {
                response = new BaseResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = new { message = "Internal server erreor : " + ex.Message }
                };

                return response;
            }
        }
    }
}
