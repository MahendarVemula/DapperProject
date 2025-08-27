using Dapper.API.Business.Contracts;
using Dapper.API.Business.Implementations;
using Dapper.API.Repository.ConnectionUtility;
using Dapper.API.Repository.Contracts;
using Dapper.API.Repository.Implementation;

namespace Dapper.API.Extensions
{
    public static class DependendyConfigurator
    {
        public static void  InjectRepositoryDependencies( this IServiceCollection services)
        {
            services.AddSingleton<IDapperDBConnection, DapperDBConnection>();
            services.AddTransient<IStudentBusiness, StudentBusiness>();
            services.AddTransient<IStudentRepository,StudentRepository>();
        }

        public static void InjectBussinessDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentBusiness, StudentBusiness>();
        }
    }
}
