using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.API.Repository.Contracts
{
    public interface IDapperDBConnection
    {
        IDbConnection GetDBConnection();
    }
}
