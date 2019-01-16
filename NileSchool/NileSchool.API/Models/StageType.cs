using System;

namespace NileSchool.API.Models
{
    public class StageType
    {
        public int Id { get; set; }
        public int StageNumber { get; set; }
        public string StageName { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}