using System;

namespace NileSchool.API.Models
{
    public class FinalScore
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int Score { get; set; }
        public SubjectGrade SubjectGradeId { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}