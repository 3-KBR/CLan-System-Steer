using System;
using Microsoft.AspNetCore.Mvc;
using Clan_System.Server.Services;
using Clan_System.Server.Models;

namespace Clan_System.Server.Controllers
{

    [Controller]
    [Route("api/[controller]")]
    public class RelationController : Controller
    {

        private readonly RelationService _relatinoService;

        public RelationController(RelationService relatinoService)
        {
            _relatinoService = relatinoService;
        }

        [HttpGet]
        public async Task<List<Relation>> Get()
        {
            return await _relatinoService.GetAsync();
        }


        [HttpGet]
        [Route("Check")]
        public async Task<Relation> GetRelationByUserName(string username)
        {
            return await _relatinoService.GetRelationByUserNameAsync(username);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Relation relation)
        {
            await _relatinoService.CreateRelationAsync(relation);
            return CreatedAtAction(nameof(Get), new { });
        }

        [HttpPut("{username},Update Points")]
        public async Task<IActionResult> UpdateRelationPoints(string username, Int32 points)
        {
            await _relatinoService.UpdateRelationPointsAsync(username, points);
            return NoContent();
        }

        [HttpPut("{username},Update Membership")]
        public async Task<IActionResult> UpdateRelationMembership(string username, Boolean isMember)
        {
            await _relatinoService.UpdateRelationMembershipAsync(username, isMember);
            return NoContent();
        }

        [HttpDelete("{username},Delete Relation")]
        public async Task<IActionResult> Delete(string username)
        {
            await _relatinoService.DeleteRelationAsync(username);
            return NoContent();
        }

        [HttpDelete("{clanname},Reset Clan Relations")]
        public async Task<IActionResult> Reset(string clanname)
        {
            await _relatinoService.ResetRelationAsync(clanname);
            return NoContent();
        }

    }
}
