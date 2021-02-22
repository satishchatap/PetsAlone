using System;

namespace Domain
{
    public interface IAuditEntity
    {
        DateTime CreatedOn { get; }
        DateTime ModifiedOn { get; }
        string CreatedBy { get; }
        string ModifiedBy { get; }
    }
}
