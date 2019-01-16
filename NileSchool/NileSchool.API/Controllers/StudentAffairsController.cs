using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NileSchool.API.Data;
using NileSchool.API.Dtos;
using NileSchool.API.Models;

namespace NileSchool.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class StudentAffairsController : ControllerBase
    {
        private readonly IAcademicYearRepository _academicYearRepo;
        private readonly IAuthRepository _authRepo;
        private readonly IGradeRepository _gradeRepo;
        private readonly IClassRepository _classRepo;
        private readonly IStudentRepository _studentRepo;

        public StudentAffairsController(IAcademicYearRepository academicYearRepo,
                                        IAuthRepository authRepo,
                                        IGradeRepository gradeRepo, 
                                        IClassRepository classRepo, 
                                        IStudentRepository studentRepo)
        {
            _academicYearRepo = academicYearRepo;
            _authRepo = authRepo;
            _gradeRepo = gradeRepo;
            _classRepo = classRepo;
            _studentRepo = studentRepo;
        }

        [HttpPost("addGrade")]
        public async Task<IActionResult> CreateGrade(GradeToCreateDto newGrade){
            
            var AcademicYear = _academicYearRepo.GetActiveYear();

            if(AcademicYear == null){
                return BadRequest("No Active Years Available");
            }

            if(await _gradeRepo.GradeExist(newGrade.Name)){
                return BadRequest("Grade with same name already exists");
            }

            int activeAcademicYearId = AcademicYear.Id;
            var gradeToCreate = new Grade{
                Name = newGrade.Name,
                AcademicYearId = activeAcademicYearId,
                AssistantPrincipalId = newGrade.AssistantPrincipalId,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now
            };

            var createdGrade = await _gradeRepo.CreateGrade(gradeToCreate);

            return Ok(createdGrade);
        }

        [HttpPost("addClass")]
        public async Task<IActionResult> CreateClass(ClassToCreateDto newClass){
            
            if(await _gradeRepo.GetGrade(newClass.GradeId) == null){
                return BadRequest("Grade do not exist");
            }

            if(await _classRepo.ClassExist(newClass.Name, newClass.GradeId)){
                return BadRequest("Class with same name already exists in the grade");
            }

            var classToCreate = new Class{
                Name = newClass.Name,
                GradeId = newClass.GradeId,
                ClassCapacity = newClass.ClassCapacity,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now
            };

            var createdClass = await _classRepo.CreateClass(classToCreate);

            return Ok(createdClass);
        }

        [HttpPost("addStudent")]
        public async Task<IActionResult> CreateStudent(StudentToCreateDto newStudent){
            
            var Class = await _classRepo.GetClass(newStudent.ClassId);

            if(Class == null){
                return BadRequest("Class do not exist");               
            }

            var studentToCreate = new Student{
                Name = newStudent.Name,
                GuardianName = newStudent.GuardianName,
                GuardianPhone = newStudent.GuardianPhone,
                GuardianMail = newStudent.GuardianMail,
                Gender = newStudent.Gender,
                DateOfBirth = newStudent.DateOfBirth,
                Address = newStudent.Address,
                ClassId = newStudent.ClassId,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now
            };

            var createdStuent = await _studentRepo.CreateStudent(studentToCreate);

            return Ok(createdStuent);
        }

        
    }
}