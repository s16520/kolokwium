using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium.Models;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium.Controllers
{
    [Route("api/championships")]
    [ApiController]
    public class ChampionshipController : Controller
    {
        private readonly s16520DbContext _context;

        public ChampionshipController(s16520DbContext context)
        {
            _context = context;

        }


        [HttpGet]
        public IActionResult GetChampionships()
        {
            return Ok(_context.Championships.ToList());
        }

        [HttpGet("{idChampionship}/teams")]
        public IActionResult GetTeamsForChampioship(int idChampionship)
        {
            Championship championship = _context.Championships.Find(idChampionship);

            if(championship == null)
            {
                return BadRequest("Nie ma takich mistrzostw");
            }

            var teams = _context.Teams.Join(_context.Championship_Teams,
                                                    team => team.IdTeam,
                                                    championship => championship.IdTeam,
                                                    (team, championship) => new { Team = team, Championship = championship }
                                                    );

            var teamsForChampionship = teams.Where(e => e.Championship.Equals(championship)).ToList();

            var res = from tmp in teamsForChampionship
                      orderby tmp.Championship.Score
                      select new
                      {
                          tmp.Team.IdTeam,
                          tmp.Team.TeamName,
                          tmp.Team.MaxAge,
                          tmp.Championship.Score
                      };

            return Ok(res);

        }
    }
}