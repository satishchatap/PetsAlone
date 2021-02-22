using System;

namespace Domain
{
    public interface IPetFactory
    {
        public Pet NewPet(string name, int type, DateTime missingSince, string photoPath);

    }
}
