using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NileSchool.API.Data.Interfaces;
using NileSchool.API.Dtos;
using NileSchool.API.Models;

namespace NileSchool.API.Controllers.EmployesControllers
{
    [Authorize(Roles="2")]
    [ApiController]
    [Route("api/[controller]")]
    public class SeniorAdminController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IUserRepository _userRepo;
        private readonly IAcademicYearRepository _academicYearRepo;

        public SeniorAdminController(IDepartmentRepository departmentRepo,
                                     IUserRepository userRepo,
                                     IAcademicYearRepository academicYearRepo)
        {
            _departmentRepo = departmentRepo;
            _userRepo = userRepo;
            _academicYearRepo = academicYearRepo;
        }

        [HttpPost("createDepartment")]
        public async Task<IActionResult> CreateDepartment(DepartmentToCreateDto departmentToCreate){

            if(await _userRepo.GetUser(departmentToCreate.HeadOfDepartmentId) == null){
                return BadRequest("User do not exist");
            }

            if(await _departmentRepo.DepartmentExist(departmentToCreate.Name)){
                return BadRequest("Department With Same Name Exists");
            }

            var newDepartment = new Department{
                Name = departmentToCreate.Name,
                UserId = departmentToCreate.HeadOfDepartmentId,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now
            };

            return (await _departmentRepo.CreateDepartment(newDepartment) != null) ? StatusCode(201) : BadRequest();
        }

        [HttpPost("addBlocksNumber")]
        public async Task<IActionResult> AddBlocksNumber(BlockNumberToAddDto blockNumberToAdd){
            
            var activeAcademicYear = await _academicYearRepo.GetActiveYear();
            if(activeAcademicYear == null){
                return BadRequest("There is no active academic year");
            }

            return (_academicYearRepo.AddBlocksNumber(activeAcademicYear, blockNumberToAdd.BlocksNumber) != null) ? StatusCode(202) : BadRequest();
        }
    }
}