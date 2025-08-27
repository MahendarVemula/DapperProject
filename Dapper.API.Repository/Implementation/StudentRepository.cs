using Dapper.API.Models.Models;
using Dapper.API.Repository.Contracts;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Dapper.API.Repository.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        //private readonly string connectionString; 
        private readonly IDapperDBConnection _dapperDBConnection;
        public StudentRepository(IDapperDBConnection dapperDBConnection)
        {
            _dapperDBConnection = dapperDBConnection;
        }

        public async Task<List<Student>> GetAsync()
        {
            using (var dbConnection = _dapperDBConnection.GetDBConnection())
            {
                List<Student> students = (await dbConnection.QueryAsync<Student>("StudentGetAll",
                    commandType: CommandType.StoredProcedure
                    )).ToList();
                return students;
            }
        }

        public async Task<Student> GetByIdAsync(int Id)
        {
            using (IDbConnection dbConnection = this._dapperDBConnection.GetDBConnection())
            {
                try
                {
                    Student student = await dbConnection.QuerySingleOrDefaultAsync<Student>("StudentGetById",
                        new { Id = Id },
                        commandType: CommandType.StoredProcedure
                        );
                    return student;
                }
                catch (Exception) { throw; }
            }
        }
        public async Task<Student> CreateStudentAsync(Student student)
        {
            using (IDbConnection dbConnection = this._dapperDBConnection.GetDBConnection())
            {
                var CreateParameters = new
                {
                    student.FirstName,
                    student.LastName
                };
                Student? dbStudent = await dbConnection.QueryFirstOrDefaultAsync<Student>("StudentCreate", CreateParameters,
                    commandType: CommandType.StoredProcedure);
                return dbStudent;
            }
        }

        public async Task<Student> UpdateAsync(Student student)
        {
            using (IDbConnection dbConnection = this._dapperDBConnection.GetDBConnection())
            {
                var updateParameters = new
                {
                    student.Id,
                    student.FirstName,
                    student.LastName,
                    student.IsEnable
                };
                Student? dbStudent = await dbConnection.QuerySingleOrDefaultAsync<Student>("StudentUpdate", updateParameters,
                    commandType: CommandType.StoredProcedure);
                return dbStudent;
            }
        }
        public async Task<bool> HasExist(string FirstName)
        {
            try
            {
                using (IDbConnection dbConnection = this._dapperDBConnection.GetDBConnection())
                {
                    dbConnection.Open();
                    Student student = (await dbConnection.QueryAsync<Student>("StudentHasExist",
                        new
                        {
                            FirstName
                        },
                        commandType: CommandType.StoredProcedure)).FirstOrDefault();
                    return student != null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
