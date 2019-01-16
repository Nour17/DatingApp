using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NileSchool.API.Data;
using NileSchool.API.Models;

namespace NileSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  
    public class AssistantPrincipalController : ControllerBase
    {
        private readonly IAssistantPrincipalRepository _repo;

        public AssistantPrincipalController(IAssistantPrincipalRepository repo)
        {
            _repo = repo;
        }  

        [HttpPost("addAP")]
        public async Task<IActionResult> AddAp(int name, int userId){
            
            var assistantPrincipalToCreate = new AssistantPrincipal{
                Stage = 1,
                UserId = 1,
                Created = DateTime.Now
            };

            var createdUser = await _repo.AddAp(assistantPrincipalToCreate);

            return StatusCode(201);
        }
    }
}