using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace SchoolWeb.API.Startup
{
	public static class MiddlewareInitializer
	{
		public static WebApplication ConfigureMiddleware(this WebApplication app)
		{
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(option =>
				{
					option.SwaggerEndpoint("/swagger/SchoolWeb.Api/swagger.json", "School Web API");
				});
			}
			else
			{
				// Use HTTP Strict Transport Security(HSTS) to tell browsers to only connect to the application over HTTPS.
				app.UseHsts();
			}

			// Redirect HTTP requests to HTTPS
			app.UseHttpsRedirection();
			app.UseStatusCodePages();
			app.UseAuthentication();
			app.UseMiddleware<ExceptionMiddleware>();
			app.UseAuthorization();
			app.MapControllers();
			return app;
		}
	}
}
