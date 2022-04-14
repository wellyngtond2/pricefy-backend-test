using System.Collections.Generic;

namespace PricefyChallenge.Core.Entities
{
    public sealed class MovieAttachment : EntityBase
    {
        public string FileId { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}