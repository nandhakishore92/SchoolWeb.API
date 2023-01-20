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
            // Unit Of Work should be one per HTTP request, as we want all the change transactions to be committed to DB in one go. Hence AddScoped.
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // As it is light weight, almost no state, it makes sense to AddTransient here.
            services.AddTransient<IStudentsService, StudentsService>();
        }

        private static void RegisterSwaggerSupport(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
