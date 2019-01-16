using System;

namespace NileSchool.API.Models
{
    public class Block
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public int BlockCriteriaId { get; set; }
        public BlockCriteria BlockCriteria { get; set; }
        public int NextBlockId { get; set; }
        public Block block { get; set; }
        public int BlockBalance { get; set; }
        public int SubjectGradeId { get; set; }
        public SubjectGrade SubjectGrade { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}