using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzTip.Models;

namespace OzTip.Data
{
    public class OzTipContext : DbContext
    {
        public OzTipContext() : base("OzTipDatabase")
        {
        }

        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tip> Tips { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            
            modelBuilder.Entity<Game>()
                .Ignore(ga => ga.HomeTeamId)
                .Ignore(ga => ga.AwayTeamId)
                .Ignore(ga => ga.HomeTeam)
                .Ignore(ga => ga.AwayTeam)
                .Ignore(ga => ga.HomeScore)
                .Ignore(ga => ga.AwayScore);

            modelBuilder.Entity<Score>()
                .Ignore(sc => sc.Total);

            modelBuilder.Entity<Competition>()
                .HasMany(co => co.Users)
                .WithMany(us => us.Competitions);

            modelBuilder.Entity<Competition>()
                .HasRequired(co => co.Owner)
                .WithOptional();
        }
    }
}