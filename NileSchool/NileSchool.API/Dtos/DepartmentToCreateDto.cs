using System.ComponentModel.DataAnnotations;

namespace NileSchool.API.Dtos
{
    public class DepartmentToCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int HeadOfDepartmentId { get; set; }
    }
}