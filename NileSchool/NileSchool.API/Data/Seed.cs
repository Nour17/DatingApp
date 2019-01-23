using System.Collections.Generic;
using Newtonsoft.Json;
using NileSchool.API.Data.Interfaces;
using NileSchool.API.Models;

namespace NileSchool.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        private readonly IAcademicYearRepository _academicYearRepo;

        public Seed(DataContext context, IAcademicYearRepository academicYearRepo)
        {
            _context = context;
            _academicYearRepo = academicYearRepo;
        }

        public void main(){
            SeedAcademicYearData();
            SeedUserTypes();
            SeedUserData();
            SeedTeacher();
            SeedAssistantPrincipal();
            SeedGradeData();
            SeedClassData();
            SeedStudent();
        }

        public void SeedUserTypes(){

            var userTypesData = System.IO.File.ReadAllText("Data/SeedData/UserTypeSeedData.json");
            var userTypesDeserialized = JsonConvert.DeserializeObject<List<UserType>>(userTypesData);

            foreach(var userType in userTypesDeserialized){
                _context.UserTypes.Add(userType);
            }

            _context.SaveChanges();
        }

        public void SeedTeacher(){

            var teahcersData = System.IO.File.ReadAllText("Data/SeedData/TeacherSeedData.json");
            var teachersDeserialized = JsonConvert.DeserializeObject<List<Teacher>>(teahcersData);

            foreach(var teacher in teachersDeserialized){
                _context.Teachers.Add(teacher);
            }

            _context.SaveChanges();
        }

        public void SeedAcademicYearData(){

            var academicYearData = System.IO.File.ReadAllText("Data/SeedData/AcademicYearData.json");
            var academicYearDeserialized = JsonConvert.DeserializeObject<List<AcademicYear>>(academicYearData);

            foreach(var academicYear in academicYearDeserialized){
                _context.AcademicYears.Add(academicYear);
            }

            _context.SaveChanges();
        }

        public void SeedAssistantPrincipal(){

            var assistantPrincipalData = System.IO.File.ReadAllText("Data/SeedData/AssistantPrincipalSeedData.json");
            var assistantPrincipalDeserialized = JsonConvert.DeserializeObject<List<AssistantPrincipal>>(assistantPrincipalData);

            foreach(var assistantPrincipal in assistantPrincipalDeserialized){
                _context.AssistantPrincipals.Add(assistantPrincipal);
            }

            _context.SaveChanges();
        }


        public void SeedClassData(){

            var classData = System.IO.File.ReadAllText("Data/SeedData/ClassSeedData.json");
            var classDeserialized = JsonConvert.DeserializeObject<List<Class>>(classData);

            foreach(var singleClass in classDeserialized){
                _context.Classes.Add(singleClass);
            }

            _context.SaveChanges();
        }

        public void SeedGradeData(){

            var gradeData = System.IO.File.ReadAllText("Data/SeedData/GradeSeedData.json");
            var gradeDeserialized = JsonConvert.DeserializeObject<List<Grade>>(gradeData);
            var AcademicYear = _academicYearRepo.GetActiveYear();

            foreach(var grade in gradeDeserialized){
                grade.AcademicYearId = AcademicYear.Id;
                _context.Grades.Add(grade);
            }

            _context.SaveChanges();
        }

        public void SeedStudent(){

            var studentData = System.IO.File.ReadAllText("Data/SeedData/StudentSeedData.json");
            var studentDeserialized = JsonConvert.DeserializeObject<List<Student>>(studentData);

            foreach(var student in studentDeserialized){
                _context.Students.Add(student);
            }

            _context.SaveChanges();
        }

        public void SeedUserData(){

            var userData = System.IO.File.ReadAllText("Data/SeedData/UserSeedData.json");
            var userDeserialized = JsonConvert.DeserializeObject<List<User>>(userData);

            foreach(var user in userDeserialized){
                byte[] passwordHash, passwordSalt;
                this.ComputePassword("password", out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();

                _context.Users.Add(user);
            }

            _context.SaveChanges();
        }

        private void ComputePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}