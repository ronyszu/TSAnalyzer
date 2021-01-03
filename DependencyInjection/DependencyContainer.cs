
using Business;
using DataAccess;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {



            services.AddDbContext<EFDbContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=TSAnalyzerDB;");   
             }
                );
            
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
 

            //services.AddScoped<Parameter>();





        }
       
    }
}
