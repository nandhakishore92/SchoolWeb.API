using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.Dtos;

namespace SchoolWeb.API.Controllers.Interfaces
{
    public interface IStudentsController
    {
        #region Student Details
        [HttpGet("{rteOnly}")]
        StudentDetailsListDto StudentDetails(bool rteOnly = false);
        #endregion
    }
}
