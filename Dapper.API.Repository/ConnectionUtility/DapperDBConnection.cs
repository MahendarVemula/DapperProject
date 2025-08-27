using Dapper.API.Repository.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.API.Repository.ConnectionUtility
{
    public class DapperDBConnection : IDapperDBConnection
    {
        private readonly string _connectionString;
        public DapperDBConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DapperProject");
        }

        public IDbConnection GetDBConnection()
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection;
        }
    }
}
