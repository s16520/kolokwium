using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium.DTOs.Requests;
using kolokwium.Models;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : Controller
    {

        private readonly s16520DbContext _context;

        public TeamController(s16520DbContext context)
        {
            _context = context;

        }

        [HttpPost("{idTeam}/players")]
        public IActionResult GetTeamsForChampioship(int idTeam, AddPlayerRequest addPlayerRequest)
        {
            Team team = _context.Teams.Find(idTeam);

            if (team == null)
            {
                return BadRequest("Nie ma takiego zespołu!");
            }

            Player player = _context.Players
                .Where(p => p.FirstName.Equals(addPlayerRequest.FirstName))
                .Where(p => p.LastName.Equals(addPlayerRequest.LastName))
                .Where(p => p.DateOfBirth.Equals(addPlayerRequest.DateOfBirth)).First();

            if(player == null)
            {
                return BadRequest("Nie ma takiego zawodnika!");
            }
           
            var age = (DateTime.Now.Year - addPlayerRequest.DateOfBirth.Value.Year);

            if(age > team.MaxAge)
            {
                return BadRequest("Zawodnik jest za stary na tę drużynę!");
            }

            var _link = _context.Player_Teams.Where(pt => pt.Player.Equals(player)).First();

            if(_link != null)
            {
                return BadRequest("Zawodnik już ma drużynę!");
            }

            Player_Team player_Team = new Player_Team();
            player_Team.Player = player;
            player_Team.Team = team;

            _context.Player_Teams.Add(player_Team);

            _context.SaveChanges();

            return Ok("Dodano");
        }
    }
}