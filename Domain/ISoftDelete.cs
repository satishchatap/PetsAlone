using System;

namespace Domain
{
    public interface ISoftDelete
    {
        DateTime DeletedOn { get; }
        string DeleteBy { get; }
        bool IsDeleted { get; }
    }
}
