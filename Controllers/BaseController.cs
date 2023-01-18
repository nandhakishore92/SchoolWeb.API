using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.DataAccessLayer;
using SchoolWeb.API.Providers;

namespace SchoolWeb.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public abstract class BaseController<TProvider> : ControllerBase where TProvider : class, IBaseProvider, new()
	{
		private TProvider m_Provider;
		public BaseController(IUnitOfWork unitOfWork)
		{
			m_Provider = (TProvider)Activator.CreateInstance(typeof(TProvider), unitOfWork);
		}

		protected TProvider Provider
		{
			get { return m_Provider; }
		}
	}
}
