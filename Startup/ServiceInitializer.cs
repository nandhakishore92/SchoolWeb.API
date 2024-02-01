using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog.Web;
using SchoolWeb.API.DataAccessLayer;
using SchoolWeb.API.Models;
using SchoolWeb.API.Services.Implementations;
using SchoolWeb.API.Services.Interfaces;
using System.Text;

namespace SchoolWeb.API.Startup
{
	public static class ServiceInitializer
	{
		public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
		{
			ConfigureNLog(builder);
			services.AddControllers();
			services.RegisterDbContextAndIdentityServices(builder);
			services.RegisterAuthenticationService(builder);
			services.RegisterCustomServices();
			services.RegisterSwaggerService();
			services.RegisterExceptionHandlerService();
			services.AddRouting(options => options.LowercaseUrls = true);
			return services;
		}

		private static void ConfigureNLog(WebApplicationBuilder builder)
		{
			builder.Logging.ClearProviders();
			// This will take take care of serving the ILogger<T> dependency injection.
			builder.Host.UseNLog();
		}

		private static void RegisterDbContextAndIdentityServices(this IServiceCollection services, WebApplicationBuilder builder)
		{
			string connectionString = builder.Configuration.GetConnectionString("SchoolDbContext");
			services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(connectionString));

			services
				.AddIdentity<ApplicationUser, ApplicationRole>(options =>
				{
					options.SignIn.RequireConfirmedAccount = false;
					options.User.RequireUniqueEmail = true;
					options.Password.RequireDigit = true;
					options.Password.RequiredLength = 8;
					options.Password.RequireNonAlphanumeric = true;
					options.Password.RequireUppercase = true;
				})
				.AddRoles<ApplicationRole>()
				.AddEntityFrameworkStores<SchoolDbContext>();
		}

		private static void RegisterAuthenticationService(this IServiceCollection services, WebApplicationBuilder builder)
		{
			// These should eventually be moved to a secrets file, but for alpha development appsettings is fine
			var validIssuer = builder.Configuration.GetValue<string>("JwtTokenSettings:ValidIssuer");
			var validAudience = builder.Configuration.GetValue<string>("JwtTokenSettings:ValidAudience");
			var symmetricSecurityKey = builder.Configuration.GetValue<string>("JwtTokenSettings:SymmetricSecurityKey");

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.IncludeErrorDetails = true;
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					ClockSkew = TimeSpan.Zero,
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = validIssuer,
					ValidAudience = validAudience,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(symmetricSecurityKey)),
				};
			});
		}

		private static void RegisterCustomServices(this IServiceCollection services)
		{

			// As we want the token to be the same for the full HTTP request cycle.
			services.AddScoped<ITokenService, TokenService>();

			// Unit Of Work should be one per HTTP request, as we want all the change transactions to be committed to DB in one go. Hence AddScoped.
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			// As it is light weight, almost no state, it makes sense to AddTransient here.
			services.AddTransient<IStudentsService, StudentsService>();
			services.AddTransient<IAccountService, AccountService>();
		}

		private static void RegisterSwaggerService(this IServiceCollection services)
		{
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen(option =>
			{
				option.SwaggerDoc("SchoolWeb.Api", new OpenApiInfo { Title = "School Web API" });
				option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Please enter a valid token",
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					BearerFormat = "JWT",
					Scheme = "Bearer"
				});
				option.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type=ReferenceType.SecurityScheme,
								Id="Bearer"
							}
						},
						new string[]{}
					}
				});
			});
		}

		private static void RegisterExceptionHandlerService(this IServiceCollection services)
		{
			services.AddTransient<ExceptionMiddleware>();
		}
	}
}
