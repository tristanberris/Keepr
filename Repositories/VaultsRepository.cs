using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Vault> Get()
        {
            string sql = "SELECT * FROM vaults;";
            return _db.Query<Vault>(sql);
        }

        internal IEnumerable<Vault> GetKeepsByVaultId(int vaultId)
        {
            string sql = @"
                SELECT 
                k.*,
                vk.id as vaultKeepId
                FROM vaultkeeps vk
                INNER JOIN keeps k ON k.id = vk.keepId 
                WHERE (vaultId = @vaultId) ";
            return _db.Query<Vault>(sql, new { vaultId});
        }

        internal Vault Create(Vault VaultData)
        {
            string sql = @"
            INSERT INTO vaults
            (id, name, description, userId)
            VALUES
            (@Id, @Name, @Description, @UserId);
            SELECT LAST_INSERT_ID()";
            VaultData.Id = _db.ExecuteScalar<int>(sql, VaultData);
            return VaultData;
            throw new NotImplementedException();
        }

          internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM vaults WHERE id = @Id AND userId = @UserId LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
        }
    }
}