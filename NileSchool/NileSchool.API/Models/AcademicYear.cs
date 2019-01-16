using System;

namespace NileSchool.API.Models
{
    public class AcademicYear
    {
        public int Id { get; set; }
        public bool isActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Coefficient { get; set; }
        public int NumberOfBlocks { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}