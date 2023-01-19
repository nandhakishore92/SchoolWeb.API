using Microsoft.EntityFrameworkCore;
using SchoolWeb.API.DataAccessLayer;
using SchoolWeb.API.Providers;

namespace SchoolWeb.API.Startup
{
    public static class ServiceInitializer
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, string connectionString)
        {
            services.AddControllers();
            services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(connectionString));
            services.RegisterCustomServices();
            services.RegisterSwaggerSupport();
            return services;
        }

        private static void RegisterCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IStudentsProvider, StudentsProvider>();
        }

        private static void RegisterSwaggerSupport(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
