using System;

namespace NileSchool.API.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HeadOfDepartmentId { get; set; }
        public User User { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }    }
}