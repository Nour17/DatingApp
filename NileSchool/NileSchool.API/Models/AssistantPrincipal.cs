using System;

namespace NileSchool.API.Models
{
    public class AssistantPrincipal
    {
        public int Id { get; set; }
        public int Stage { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Created { get; set; }
    }
}