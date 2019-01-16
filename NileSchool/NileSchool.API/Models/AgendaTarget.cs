using System;

namespace NileSchool.API.Models
{
    public class AgendaTarget
    {
        public int Id { get; set; }
        public int AgendaId { get; set; }
        public Agenda Agenda { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Created { get; set; }
    }
}