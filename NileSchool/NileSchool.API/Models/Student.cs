using System;

namespace NileSchool.API.Models
{
    public class Student
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string GuardianName { get; set; }
       public bool Gender { get; set; }
       public DateTime DateOfBirth { get; set; }
       public string Address { get; set; }
       public string GuardianMail { get; set; }
       public string GuardianPhone { get; set; }
       public int ClassId { get; set; }
       public Class Class { get; set; }
       public DateTime Created { get; set; }
       public DateTime LastUpdated { get; set; } 
    }
}