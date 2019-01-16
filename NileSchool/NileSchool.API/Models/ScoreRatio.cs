using System;

namespace NileSchool.API.Models
{
    public class ScoreRatio
    {
        public int Id { get; set; }
        public char CharactirizedGrade { get; set; }
        public int MinScore { get; set; }
        public int MaxScore { get; set; }
        public int AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}