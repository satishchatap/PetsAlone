using System;
using System.Collections.Generic;
using System.Text;

namespace PetsAlone.Core.Domain
{
    public interface IAuditEntity
    {
        public DateTime CreatedOn { get; }
        public DateTime ModifiedOn { get; }
        public string CreatedBy { get; }
        public string ModifiedBy { get; }
    }
}
