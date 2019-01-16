using System;

namespace NileSchool.API.Models
{
    public class ClassSubjectGrade
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int SubjectGradeId { get; set; }
        public SubjectGrade SubjectGrade { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}