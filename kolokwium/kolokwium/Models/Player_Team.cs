using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class Player_Team
    {
        [ForeignKey("Player")]
        public int IdPlayer { get; set; }

        [ForeignKey("Team")]
        public int IdTeam { get; set; }

        public int NumOfShirt { get; set; }
        [MaxLength(300)]
        public string Comment { get; set; }

        public virtual Player Player { get; set; }
        public virtual Team Team { get; set; }
    }
}
