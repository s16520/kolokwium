using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class Championship_Team
    {
        [ForeignKey("Team")]
        public int IdTeam { get; set; }

        [ForeignKey("Championship")]
        public int IdChampionship { get; set; }

        public float Score { get; set; }

        public virtual Team Team { get; set; }
        public virtual Championship Championship { get; set; }
    }
}
