using System;

namespace NileSchool.API.Models
{
    public class TempTeachers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
    }
}