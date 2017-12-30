using KeenanBuff.Entities;
using System.Data.Entity;

namespace KeenanBuff.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ApplicationDbContext") { }

        public DbSet<MatchDetail> MatchDetails { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<PlayerItem> PlayerItems { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { } 
    }
}