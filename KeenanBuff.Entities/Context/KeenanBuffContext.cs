using KeenanBuff.Entities;
using KeenanBuff.Entities.Context.Interfaces;
using System.Data.Entity;

namespace KeenanBuff.Entities.Context
{
    public class KeenanBuffContext : DbContext, IKeenanBuffContext
    {
        public KeenanBuffContext() : base("KeenanBuffContext") { }

        public IDbSet<MatchDetail> MatchDetails { get; set; }
        public IDbSet<Match> Matches { get; set; }
        public IDbSet<PlayerItem> PlayerItems { get; set; }
        public IDbSet<Hero> Heroes { get; set; }
        public IDbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { } 
    }
}