using System.ComponentModel.DataAnnotations;

namespace NileSchool.API.Dtos
{
    public class GradeToCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int AssistantPrincipalId { get; set; }
    }
}