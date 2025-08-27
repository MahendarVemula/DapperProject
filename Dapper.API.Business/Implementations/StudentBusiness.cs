using Dapper.API.Business.Contracts;
using Dapper.API.Models.Models;
using Dapper.API.Repository.Contracts;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.API.Business.Implementations
{
    public class StudentBusiness : IStudentBusiness
    {
        private IStudentRepository _studentRepository; 
        public StudentBusiness(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<List<Student>> GetAsync()
        {
            List<Student> dbStudents = await _studentRepository.GetAsync();
            return dbStudents; 
        }
        public async Task<Student> GetByIdAsync(int Id)
        {
            Student student = await _studentRepository.GetByIdAsync(Id);
            return student;
        }
        public async Task<Student> CreateStudentAsync(Student student)
        {
            Student inputStudent = await _studentRepository.CreateStudentAsync(student);
            return inputStudent;
        }
        public async Task<Student> UpdateAsync(Student student)
        {
            Student updateStudent = await _studentRepository.UpdateAsync(student);
            return updateStudent;
        }
        public async Task<bool> HasExist(string FirstName)
        {
            return await _studentRepository.HasExist(FirstName);
        }
    }
}
