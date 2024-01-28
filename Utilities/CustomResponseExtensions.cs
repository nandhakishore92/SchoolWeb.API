using Microsoft.AspNetCore.Mvc;

namespace SchoolWeb.API.Utilities
{
	public static class CustomResponseExtensions
	{
		public static IActionResult ToActionResult(this CustomResponse response, string createdLocation = "")
		{
			return response.StatusCode switch
			{
				200 => new OkObjectResult(response.Message),
				201 => new CreatedResult(createdLocation, response.Message),
				202 => new AcceptedResult(createdLocation, response.Message),
				204 => new NoContentResult(),
				400 => new BadRequestObjectResult(response.Message),
				401 => new UnauthorizedObjectResult(response.Message),
				404 => new NotFoundObjectResult(response.Message),
				409 => new ConflictObjectResult(response.Message),
				422 => new UnprocessableEntityObjectResult(response.Message),
				_ => new ObjectResult(response.Message) { StatusCode = response.StatusCode },
			};
		}

		public static bool IsBadResponse(this CustomResponse response)
		{
			var badStatusCodes = new[] { 400, 401, 404, 409, 422 };
			return badStatusCodes.Contains(response.StatusCode);
		}
	}
}
