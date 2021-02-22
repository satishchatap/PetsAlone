using Microsoft.EntityFrameworkCore;
using PetsAlone.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PetsAlone.Core
{
    public class PetsService : IPetsService
    {
        private readonly PetsDbContext _petsDbContext; 
        private readonly ClaimsPrincipal _user;
        public PetsService(PetsDbContext petsDbContext, ClaimsPrincipal user)
        {
            _petsDbContext = petsDbContext;
            _user = user;
        }

        public List<Pet> GetAll()
        {
            return _petsDbContext.Pets.ToListAsync().Result?.OrderByDescending(a => a.MissingSince).ToList();
        }
        public Pet Get(int id)
        {
            return _petsDbContext.Pets.Find(id);
        }
        public Pet Create(Pet pet)
        {
            _petsDbContext.Pets.Add(pet);
            _petsDbContext.SaveChanges();
            return pet;
        }
        public bool Update(Pet pet)
        {
            _petsDbContext.Pets.Update(pet);
            return _petsDbContext.SaveChanges() == 1;
        }
        public bool Delete(int id)
        {
            var pet = _petsDbContext.Pets.Find(id);
            _petsDbContext.Pets.Remove(pet);
            return _petsDbContext.SaveChanges() == 1;
        }
    }
}