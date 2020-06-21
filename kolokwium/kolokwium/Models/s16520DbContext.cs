using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class s16520DbContext :DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Player_Team> Player_Teams { get; set; }
        public DbSet<Championship_Team> Championship_Teams { get; set; }
        public s16520DbContext() { }

        public s16520DbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Championship_Team>()
                .HasKey(c => new { c.IdChampionship, c.IdTeam });

            modelBuilder.Entity<Player_Team>()
                .HasKey(c => new { c.IdPlayer, c.IdTeam });

        }

    }
}
