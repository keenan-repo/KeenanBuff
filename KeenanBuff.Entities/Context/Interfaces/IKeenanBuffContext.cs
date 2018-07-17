using System;
using System.Data.Entity;

namespace KeenanBuff.Entities.Context.Interfaces
{
    public interface IKeenanBuffContext : IDisposable
    {
        IDbSet<MatchDetail> MatchDetails { get; set; }
        IDbSet<Match> Matches { get; set; }
        IDbSet<PlayerItem> PlayerItems { get; set; }
        IDbSet<Hero> Heroes { get; set; }
        IDbSet<Item> Items { get; set; }
        Database Database { get; }
        int SaveChanges();
    }
}
