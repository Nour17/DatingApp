using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NileSchool.API.Data;
using NileSchool.API.Dtos;
using NileSchool.API.Models;

namespace NileSchool.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HeadOfCenterController : ControllerBase
    {
        private readonly IAcademicYearRepository _repo;

        public HeadOfCenterController(IAcademicYearRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("newAcademicyear")]
        public async Task<IActionResult> CreateNewAcademicYear(NewAcademicYearDto newAcademicYearDto){
            var activeChecker = await _repo.GetActiveYear();

            if(activeChecker != null){
                return BadRequest("A Year is Already Working");
            }

            var academicYearToCreate = new AcademicYear{
                StartDate = newAcademicYearDto.StartDate,
                EndDate = newAcademicYearDto.EndDate,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                isActive = true           
            };

            var createdAcademicYear = await _repo.CreateAcadmicYear(academicYearToCreate);

            return Ok(createdAcademicYear);
        }

        
    }
}