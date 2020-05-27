using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;
        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Vault> Get()
        {
            return _repo.Get();
        }

        public IEnumerable<Vault> GetKeepsByVaultId(int id)
        {
            
            
            return _repo.GetKeepsByVaultId(id);
        }

        public Vault Create(Vault newVault)
        {
            return _repo.Create(newVault);
        }

        internal string Delete(int id, string userId)
        {
            // Vault foundVault = GetById(id);
            // if (foundVault.UserId != userId )
            // {
            //     throw new Exception("This is not your Vault!");
            // }
            if (_repo.Delete(id, userId ))
            {
                return "Successfully deleted";
            }
            throw new Exception("Something didn't work");
        }
    }
}