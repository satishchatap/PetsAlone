using System;

namespace PetsAlone.Core.Domain
{
    public interface ISoftDelete
    {
        public DateTime DeletedOn { get; }
        public string DeleteBy { get; }
        public bool IsDeleted { get; }
    }
}
