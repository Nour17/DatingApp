using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NileSchool.API.Data;
using NileSchool.API.Data.Interfaces;
using NileSchool.API.Dtos;
using NileSchool.API.Models;

namespace NileSchool.API.Controllers.EmployesControllers
{
    [Authorize(Roles="8")]
    [ApiController]
    [Route("api/[controller]")]
    public class HumanResourcesController : ControllerBase
    {
        private readonly IUserRepository _authRepo;
        private readonly IUserTypeRepository _userRepo;
        private readonly IAssistantPrincipalRepository _apRepo;
        private readonly ITeacherRepository _teacherRepo;
        private readonly IDepartmentRepository _departmentRepo;

        public HumanResourcesController(IUserRepository authRepo, 
                                        IUserTypeRepository userRepo, 
                                        IAssistantPrincipalRepository apRepo, 
                                        ITeacherRepository teacherRepo,
                                        IDepartmentRepository departmentRepo)
        {
            _authRepo = authRepo;
            _userRepo = userRepo;
            _apRepo = apRepo;
            _teacherRepo = teacherRepo;
            _departmentRepo = departmentRepo;
        }

        [HttpPost("makeUser")]
        public async Task<IActionResult> MakeUser(UserForRegisterDto newUser){
            
            newUser.Username = newUser.Username.ToLower();

            if(await _authRepo.UserExists(newUser.Username)){
                return BadRequest("Username already exists");
            }

            var userToCreate = new User{
                Name = newUser.Name,
                Username = newUser.Username,
                Email = newUser.Email,
                SSN = newUser.SSN,
                UserTypeId = newUser.UserType
            };
            
            var createdUser = await _authRepo.MakeUser(userToCreate, newUser.Password);

            if(newUser.UserType == 4){
                if(!AddAssitantPrincipal(createdUser.Id)){
                    return BadRequest("AssistantPrinciapl Creation Failed");
                }
            }else if(newUser.UserType == 6){
                if(!AddTeahcer(createdUser.Id)){
                    return BadRequest("Teacher Creation Failed");
                }
            }

            return StatusCode(201);
        }

        [HttpPost("addTeacherToDepartment")]
        public IActionResult AssignTeacherToDeparmtnet(TeacherToDepartmentDto teacherToDepartment){
            
            var teacher = _teacherRepo.GetTeacherToUpdate(teacherToDepartment.TeacherId);
            if(teacher == null){
                return BadRequest("Teacher do not exist");
            }
            
            if(_departmentRepo.GetDepartment(teacherToDepartment.DepartmentId) == null){
                return BadRequest("Department do not exist");
            }

            return (_teacherRepo.AddTeacherToDepartment(teacher, teacherToDepartment.DepartmentId) != null) ? StatusCode(202) : BadRequest();
        }

        private bool AddAssitantPrincipal(int userId){
            
            var assistantPrincipalToCreate = new AssistantPrincipal{
                UserId = userId,
                Created = DateTime.Now
            };

            return (_apRepo.AddAp(assistantPrincipalToCreate) != null) ? true : false;
        }

        private bool AddTeahcer(int userId){
            
            var TeahcerToCreate = new Teacher{
                UserId = userId
            };

            return (_teacherRepo.CreateTeacher(TeahcerToCreate) != null) ? true : false;
        }
    }
}