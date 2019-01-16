using System;

namespace NileSchool.API.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int BlockCriteriaId { get; set; }
        public BlockCriteria BlockCriteria { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public string Comment { get; set; }
        public int StudentScore { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}