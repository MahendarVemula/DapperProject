using Dapper.API.Models.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.API.Repository.Contracts
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAsync();
        Task<Student> GetByIdAsync(int Id);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateAsync(Student student);
        Task<bool> HasExist(string FirstName);

    }
}
