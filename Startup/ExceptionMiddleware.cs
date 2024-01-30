using SchoolWeb.API.Utilities;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace SchoolWeb.API.Startup
{
	public class ExceptionMiddleware : IMiddleware
	{
		private readonly ILogger<ExceptionMiddleware> _logger;
		private readonly IHostEnvironment _environment;
		public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, IHostEnvironment environment)
		{
			_logger = logger;
			_environment = environment;
		}

		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try 
			{
				await next(context);
				if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
				{
					_logger.LogWarningWithPrefix("Unauthorized request");
				}
				else if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
				{
					_logger.LogWarningWithPrefix("Unauthenticated request");
				}
			}
			catch (Exception ex)
			{
				_logger.LogErrorWithPrefix(ex, ex.Message);
				await HandleExceptionAsync(context, ex);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			context.Response.ContentType = MediaTypeNames.Application.Json;
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			var response = _environment.IsDevelopment()
				? new CustomResponse(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
				: new CustomResponse(context.Response.StatusCode, "Internal Server Error");
			var json = JsonSerializer.Serialize(response);
			await context.Response.WriteAsync(json);
		}
	}
}
