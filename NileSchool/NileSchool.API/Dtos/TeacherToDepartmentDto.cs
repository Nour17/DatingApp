using System.ComponentModel.DataAnnotations;

namespace NileSchool.API.Dtos
{
    public class TeacherToDepartmentDto
    {
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}