namespace SchoolWeb.API.Utilities
{
	public class CustomResponse
	{
		public int StatusCode { get; }
		public object Message { get; }
		public string Details { get; }

		public CustomResponse(int statusCode, object message, string details = "")
		{
			StatusCode = statusCode;
			Message = message;
			Details = details;
		}
	}
}
