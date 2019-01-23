using System.ComponentModel.DataAnnotations;

namespace NileSchool.API.Dtos
{
    public class StudentToClassDto
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int ClassId { get; set; }
    }
}