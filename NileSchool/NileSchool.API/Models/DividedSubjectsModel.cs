using System;

namespace NileSchool.API.Models
{
    public class DividedSubjectsModel
    {
        public int Id { get; set; }
        public string MainName { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}