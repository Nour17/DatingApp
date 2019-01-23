using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NileSchool.API.Controllers.EmployesControllers
{
    [Authorize(Roles="5")]
    [ApiController]
    [Route("api/[controller]")]
    public class HeadOfDepartmentController : ControllerBase
    {
        public HeadOfDepartmentController()
        {
            
        }
    }
}