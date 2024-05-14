
using System;
using Microsoft.AspNetCore.Mvc;
using Clan_System.Server.Services;
using Clan_System.Server.Models;

namespace Clan_System.Server.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class ClanController : Controller
    {
        private readonly ClanService _clanService;

        public ClanController(ClanService clanService)
        {
            _clanService = clanService;
        }

        


        [HttpGet]
        public async Task<List<Clan>> Get()
        {
            return await _clanService.GetAsync();
        }


        [HttpGet("{clanname}")]
        public async Task<Clan> GetByClanName(string clanname)
        {
            return await _clanService.GetByClanAsync(clanname);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Clan clan)
        {
            await _clanService.CreateAsync(clan);
            return CreatedAtAction(nameof(Get), new { });
        }


        [HttpPut("{clanname},Update Members")]
        public async Task<IActionResult> UpdateMembers(string clanname, Int32 totalmembers)
        {
            await _clanService.UpdateMembersAsync(clanname, totalmembers);
            return NoContent();
        }


        [HttpPut("{clanname},Update Points")]
        public async Task<IActionResult> UpdatePoints(string clanname, Int32 totalpoints)
        {
            await _clanService.UpdatePointsAsync(clanname, totalpoints);
            return NoContent();
        }
    }
}
