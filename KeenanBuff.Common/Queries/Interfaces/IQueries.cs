using KeenanBuff.Entities;
using System.Linq;


namespace KeenanBuff.Common.Queries.Interfaces
{
    public interface IQueries
    {
        IQueryable<MatchDetail> GetWonMatches();
        IQueryable<MatchDetail> GetMyMatcheDetails();
    }
}