using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultKeepService
    {
        private readonly VaultKeepRepository _repo;
        public VaultKeepService(VaultKeepRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<VaultKeep> Get()
        {
            return _repo.Get();
        }

        public IEnumerable<VaultKeepViewModel> GetById(int id, string userId)
        {
            
            return _repo.GetById( id,  userId);
        }

        public VaultKeep Create(VaultKeep newVaultKeep)
        {
            return _repo.Create(newVaultKeep);
        }

        // internal string Delete(int id, string userId)
        // {
        //     VaultKeepViewModel foundVaultKeep = GetById(id, userId);
        //     if (foundVaultKeep.UserId != userId )
        //     {
        //         throw new Exception("This is not your Vault!");
        //     }
        //     if (_repo.Delete(id, userId ))
        //     {
        //         return "Successfully deleted";
        //     }
        //     throw new Exception("Something didn't work");
        // }
    }
}