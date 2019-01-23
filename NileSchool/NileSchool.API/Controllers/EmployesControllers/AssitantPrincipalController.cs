using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NileSchool.API.Data;
using NileSchool.API.Data.Interfaces;
using NileSchool.API.Models;

namespace NileSchool.API.Controllers.EmployesControllers
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
    }
}