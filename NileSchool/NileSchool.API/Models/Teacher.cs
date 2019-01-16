namespace NileSchool.API.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Position { get; set; }
    }
}