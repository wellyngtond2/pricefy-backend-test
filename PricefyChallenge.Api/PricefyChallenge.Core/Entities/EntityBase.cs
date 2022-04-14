using System;

namespace PricefyChallenge.Core.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    }
}
