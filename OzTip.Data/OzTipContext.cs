using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OzTip.Models;
using System.Diagnostics;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using OzTip.Interfaces;

namespace OzTip.Data
{
    public class OzTipContext : IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public OzTipContext() : base("OzTipDatabase")
        {
            Database.Log = s => Debug.WriteLine(s);
        }

        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tip> Tips { get; set; }
        public DbSet<Venue> Venues { get; set; }

        public static OzTipContext Create()
        {
            return new OzTipContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Game>()
                .Ignore(ga => ga.HomeTeam)
                .Ignore(ga => ga.AwayTeam)
                .Ignore(ga => ga.HomeScore)
                .Ignore(ga => ga.AwayScore);

            modelBuilder.Entity<Game>()
                .HasRequired(ga => ga.Venue)
                .WithMany()
                .HasForeignKey(ga => ga.VenueId);

            modelBuilder.Entity<Score>()
                .Ignore(sc => sc.Total);

            modelBuilder.Entity<Team>()
                .HasMany(te => te.Scores)
                .WithRequired(sc => sc.Team);

            modelBuilder.Entity<Competition>()
                .HasMany(co => co.Users)
                .WithMany(us => us.Competitions);

            modelBuilder.Entity<Competition>()
                .HasRequired(co => co.Owner)
                .WithMany()
                .HasForeignKey(co => co.UserId);

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserLogin>()
                .HasKey(ur => new { ur.UserId, ur.ProviderKey });
        }

        public override int SaveChanges()
        {
            var now = DateTime.UtcNow;

            foreach (var entry in (this as IObjectContextAdapter).ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified))
            {
                if (entry.IsRelationship) continue;

                var record = entry.Entity as IHasTimeStamps;

                if (record == null) continue;

                if (entry.State == EntityState.Added)
                    record.Created = now;

                record.Updated = now;
            }

            return base.SaveChanges();
        }
    }
}