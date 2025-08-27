using Dapper.API.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.API.Business.Contracts
{
    public interface IStudentBusiness
    {
        Task<List<Student>> GetAsync();
        Task<Student> GetByIdAsync(int Id);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateAsync(Student student);
        Task<bool> HasExist(string FirstName);
    }
}
