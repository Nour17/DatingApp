using System.ComponentModel.DataAnnotations;

namespace NileSchool.API.Dtos
{
    public class SubjectToCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool isDivided { get; set; }
    }
}