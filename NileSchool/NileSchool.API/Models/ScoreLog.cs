using System;

namespace NileSchool.API.Models
{
    public class ScoreLog
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public DateTime Created { get; set; }
    }
}