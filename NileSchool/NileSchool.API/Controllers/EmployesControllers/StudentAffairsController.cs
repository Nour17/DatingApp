using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NileSchool.API.Data;
using NileSchool.API.Data.Interfaces;
using NileSchool.API.Dtos;
using NileSchool.API.Models;

namespace NileSchool.API.Controllers.EmployesControllers
{
    [ApiController]
    [Authorize(Roles = "7")]
    [Route("api/[controller]")]
    public class StudentAffairsController : ControllerBase
    {
        private readonly IAcademicYearRepository _academicYearRepo;
        private readonly IUserRepository _authRepo;
        private readonly IGradeRepository _gradeRepo;
        private readonly IClassRepository _classRepo;
        private readonly IStudentRepository _studentRepo;

        public StudentAffairsController(IAcademicYearRepository academicYearRepo,
                                        IUserRepository authRepo,
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

        [HttpPost("createGrade")]
        public async Task<IActionResult> CreateGrade(GradeToCreateDto newGrade){
            
            var AcademicYear = _academicYearRepo.GetActiveYear();

            if(AcademicYear == null){
                return BadRequest("No Active Years Available");
            }

            if(await _gradeRepo.GradeExist(newGrade.Name)){
                return BadRequest("Grade with same name already exists");
            }

            // Check if newGrade.AssistantPrincipalId is assistant principal

            var gradeToCreate = new Grade{
                Name = newGrade.Name,
                AcademicYearId = AcademicYear.Id,
                AssistantPrincipalId = newGrade.AssistantPrincipalId,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now
            };

            return (await _gradeRepo.CreateGrade(gradeToCreate) != null) ? StatusCode(201) : BadRequest();
        }

        [HttpPost("createClass")]
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

            return (await _classRepo.CreateClass(classToCreate) != null) ? StatusCode(201) : BadRequest();
        }

        [HttpPost("createStudent")]
        public async Task<IActionResult> CreateStudent(StudentToCreateDto newStudent){
            
            String classValidator = await ClassValidator(newStudent.ClassId);

            if(classValidator != "Valid Class"){
                return BadRequest(classValidator);               
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

            return (await _studentRepo.CreateStudent(studentToCreate) != null) ? StatusCode(201) : BadRequest();
        }

        [HttpPost("addStudentToClass")]
        public async Task<IActionResult> AddStudentToClass(StudentToClassDto studentToClass){
            
            Student student = _studentRepo.GetStudent(studentToClass.StudentId);
            String classValidator = await ClassValidator(studentToClass.ClassId);

            if(student == null){
                    return BadRequest("Student do not exist");               
            }

            if(classValidator != "Valid Class"){
                return BadRequest(classValidator);               
            }

            return (_studentRepo.AddStudentToClass(student, studentToClass.ClassId) != null) ? StatusCode(202) : BadRequest();
        }

        private async Task<String> ClassValidator(int classId){
            if(classId != 0){
                var Class = await _classRepo.GetClass(classId);

                if(Class == null){
                    return "Class do not exist";               
                }

                if(_studentRepo.GetNumberOfStudentsInClass(classId) == Class.ClassCapacity){
                    return "Class reached maximum capacity";               
                }
            }
            return "Valid Class";
        }
    }
}