using System;

namespace NileSchool.API.Models
{
    public class StudentMail
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}