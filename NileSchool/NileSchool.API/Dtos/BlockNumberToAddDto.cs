using System.ComponentModel.DataAnnotations;

namespace NileSchool.API.Dtos
{
    public class BlockNumberToAddDto
    {
        [Required]
        public int BlocksNumber { get; set; }
    }
}