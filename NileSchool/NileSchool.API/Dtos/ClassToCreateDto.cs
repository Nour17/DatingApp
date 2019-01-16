using System.ComponentModel.DataAnnotations;

namespace NileSchool.API.Dtos
{
    public class ClassToCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int GradeId { get; set; }
        [Required]
        public int ClassCapacity { get; set; }
    }
}