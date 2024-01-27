namespace SchoolWeb.API.Startup
{
    public static class MiddlewareInitializer
    {
        public static WebApplication ConfigureMiddleware(this WebApplication app)
        {
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(option =>
                {
					option.SwaggerEndpoint("/swagger/SchoolWeb.Api/swagger.json", "School Web API");
				});
			}

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
