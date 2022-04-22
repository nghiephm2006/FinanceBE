
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Reso.Core.BaseConnect;
using Finance.Data.Models;
using VuonDau.Data.Repositories;
using Finance.Business.Services;

namespace Finance.Business.Gens.DependencyInjection
{
    public static class DependencyInjectionResolverGen
    {
        public static void InitializerDI(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbContext, financeFPTContext>();
        
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
        }
    }
}
