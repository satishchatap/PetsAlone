using System;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Object domain driven desing pattern
    /// Entities are mutable.
    /// Entities are highly abstract.
    /// Entities do not need to be serializable.
    /// The entity state should be encapsulated to external access.
    /// </summary>
    public readonly struct PetId : IEquatable<PetId>
    {
        public Guid Id { get; }

        public PetId(Guid id) =>
            this.Id = id;

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            return obj is PetId o && this.Equals(o);
        }

        public bool Equals(PetId other) => this.Id == other.Id;

        public override int GetHashCode() =>
            HashCode.Combine(this.Id);

        public static bool operator ==(PetId left, PetId right) => left.Equals(right);

        public static bool operator !=(PetId left, PetId right) => !(left == right);

        public override string ToString() => this.Id.ToString();
    }
}
