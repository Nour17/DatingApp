using System;

namespace NileSchool.API.Models
{
    public class BlockCriteria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Block Block { get; set; }
        public int BlockId { get; set; }
        public int MaxValue { get; set; }
        public int NextCriteriaId { get; set; }
        public BlockCriteria Blockcriteria { get; set; }
        public int Position { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}