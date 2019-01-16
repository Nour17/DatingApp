using Microsoft.EntityFrameworkCore;
using NileSchool.API.Models;

namespace NileSchool.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options){}
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<AssistantPrincipal> AssistantPrincipals { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}