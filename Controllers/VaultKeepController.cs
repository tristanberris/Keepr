using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultKeepController : ControllerBase
    {
        private readonly VaultKeepService _vks;
        public VaultKeepController(VaultKeepService vks)
        {
            _vks = vks;
        }
        [HttpGet]
        public ActionResult<IEnumerable<VaultKeep>> Get()
        {
            try
            {
                return Ok(_vks.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

        //  NOTE path is https://localhost:5001/api/VaultKeep/id
        // https://localhost:5001/api/Vault/3/keeps
        [HttpGet("{id}")]
        public ActionResult<VaultKeepViewModel> GetById(int id)
        {
            try
            {
                //http context, claimtype name identifer
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                string userId = user.Value;
                return Ok(_vks.GetById(id, userId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult<VaultKeep> Post([FromBody] VaultKeep newVaultKeep)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newVaultKeep.UserId = userId;
                return Ok(_vks.Create(newVaultKeep));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

        // [Authorize]
        // [HttpDelete("{id}")]
        // public ActionResult<string> Delete(int id)
        // {
        //     try
        //     {
        //         Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        //         if (user == null)
        //         {
        //             throw new Exception("you must be logged in to delete");
        //         }
        //         string userId = user.Value;
        //         return Ok(_vks.Delete(id, userId));
        //     }
        //     catch (SystemException error)
        //     {
        //         return BadRequest(error.Message);
        //     }
        // }
    }
}