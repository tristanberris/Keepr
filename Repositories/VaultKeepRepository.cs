using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultKeepRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<VaultKeep> Get()
        {
            string sql = "SELECT * FROM vaultkeeps;";
            return _db.Query<VaultKeep>(sql);
        }

        internal IEnumerable<VaultKeepViewModel> GetById(int vaultId, string UserId)
        {
            string sql = @"
                SELECT 
                k.*,
                vk.id as vaultKeepId
                FROM vaultkeeps vk
                INNER JOIN keeps k ON k.id = vk.keepId 
                WHERE (vaultId = @vaultId AND vk.userId = @UserId) ";
            return _db.Query<VaultKeepViewModel>(sql, new { vaultId, UserId });
        }

        internal VaultKeep Create(VaultKeep VaultKeepData)
        {
            string sql = @"
            INSERT INTO vaultkeeps
            (id, vaultId, keepId, userId)
            VALUES
            (@Id, @VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID()";
            VaultKeepData.Id = _db.ExecuteScalar<int>(sql, VaultKeepData);
            return VaultKeepData;
            throw new NotImplementedException();
        }

        // internal bool Delete(int id, string userId)
        // {
        //     string sql = "DELETE FROM vaultkeeps WHERE id = @Id AND userId = @UserId LIMIT 1";
        //     int affectedRows = _db.Execute(sql, new { id, userId });
        //     return affectedRows == 1;
        // }
    }
}