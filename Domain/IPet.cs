using Domain.ValueObjects;
using System;

namespace Domain
{
    public interface IPet : IAuditEntity
    {
        // the id
        Guid Id { get; set; }

        // the name
        string Name { get; set; }

        // type
        int PetType { get; set; } 

        // missing since
        DateTime MissingSince { get; set; }
        string? PhotoPath { get; set; }
    }
}
