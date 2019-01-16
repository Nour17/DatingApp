using System;
using System.ComponentModel.DataAnnotations;

namespace NileSchool.API.Dtos
{
    public class NewAcademicYearDto
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}