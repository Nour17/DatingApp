using System;

namespace NileSchool.API.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public int AssistantPrincipalId { get; set; }
        public AssistantPrincipal AssistantPrincipal { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}