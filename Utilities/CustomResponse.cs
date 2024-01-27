namespace SchoolWeb.API.Utilities
{
	public class CustomResponse
	{
		public int StatusCode { get; }
		public string Message { get; }
		public string Details { get; }
		public CustomResponse(int statusCode, string message, string details = "")
		{
			StatusCode = statusCode;
			Message = message;
			Details = details;
		}
	}
}
