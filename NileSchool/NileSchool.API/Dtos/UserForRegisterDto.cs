using System.ComponentModel.DataAnnotations;

namespace NileSchool.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Username { get; set; }
        
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "Enter the right Social Security Number")]
        public string SSN{ get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 8")]
        public string Password{ get; set; }

        [Required]
        public int UserType { get; set; }
    }
}