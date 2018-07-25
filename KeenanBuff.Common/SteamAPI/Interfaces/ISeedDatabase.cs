using KeenanBuff.Entities.Context.Interfaces;

namespace KeenanBuff.Entities.SteamAPI.Interfaces
{
    public interface ISeedDatabase
    {
        void Update(IKeenanBuffContext context, int NumOfMatches);
    }
}
