using Microsoft.AspNetCore.Mvc;

namespace SchoolWeb.API.Controllers.Implementations
{
	public abstract class BaseController : ControllerBase
	{
		protected string CreateUrl(string actionName, string controllerName, object routeValues)
		{
			return Url.Action(actionName, controllerName.Replace("Controller", ""), routeValues, Request.Scheme);
		}
	}
}
