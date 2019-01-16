using System;
using System.ComponentModel.DataAnnotations;

namespace NileSchool.API.Dtos
{
    public class StudentToCreateDto
    {
        [Required]    
        public string Name { get; set; }
        [Required]    
        public string GuardianName { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string GuardianMail { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11)]
        public string GuardianPhone { get; set; }
        public int ClassId { get; set; }
    }
}