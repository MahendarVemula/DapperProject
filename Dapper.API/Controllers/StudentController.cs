using Dapper.API.Business.Contracts;
using Dapper.API.Models.Common;
using Dapper.API.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentBusiness _studentBusiness;
        public StudentController(IStudentBusiness studentBusiness)
        {
            _studentBusiness = studentBusiness;
        }
        [HttpGet("GetStudentAll")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                List<Student> students = await _studentBusiness.GetAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("GetStudentById")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            try
            {
                Student student = await _studentBusiness.GetByIdAsync(Id);
                return Ok(student);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync(Student student)
        {
            try
            {
                string Message = "";
                if (student == null)
                {
                    Message = ApplicationMessages.InputValuesNull;
                    return Ok(Message);
                }
                student = await _studentBusiness.CreateStudentAsync(student);
                Message = ApplicationMessages.CreatedSuccessfully;
                return Ok(Message);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Student student)
        {
            try
            {
                string Message = "";
                if (student == null || student.Id <=0)
                {
                    Message = ApplicationMessages.InputValuesNull;
                    return BadRequest(Message);
                }
                student = await _studentBusiness.UpdateAsync(student);
                Message = ApplicationMessages.UpdateSuccessfully;
                return Ok(Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("HasExist")]
        public async Task<IActionResult> HasExist(string FirstName)
        {
            try
            {
                Response response = new Response
                {
                    Message = string.Empty,
                    Success = false,
                };
                bool student = await _studentBusiness.HasExist(FirstName);
                response.Success = student;
                response.Message = ApplicationMessages.AlreadyExists;
                return Ok(response);

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
