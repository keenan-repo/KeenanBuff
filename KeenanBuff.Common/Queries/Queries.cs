using KeenanBuff.Common.Logger.Interfaces;
using KeenanBuff.Common.Queries.Interfaces;
using KeenanBuff.Entities;
using KeenanBuff.Entities.Context.Interfaces;
using System.Linq;

namespace KeenanBuff.Common.Queries
{
    public class Queries : IQueries
    {
        private readonly IKeenanBuffContext _context;
        private readonly IFileLogger _fileLogger;

        public Queries(IKeenanBuffContext context, IFileLogger fileLogger)
        {
            _context = context;
            _fileLogger = fileLogger;
        }

        public IQueryable<MatchDetail> GetWonMatches()
        {
            return _context.MatchDetails
                  .Where(x => x.PlayerID == 90935174 && ((x.PlayerSlot < 6 && x.Match.RadiantWin) || (x.PlayerSlot > 5 && !x.Match.RadiantWin)));
        }

        public IQueryable<MatchDetail> GetMyMatcheDetails()
        {
            return _context.MatchDetails.Where(x => x.PlayerID == 90935174);
        }
    }
}
