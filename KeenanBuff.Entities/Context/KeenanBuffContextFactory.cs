using KeenanBuff.Entities.Context.Interfaces;

namespace KeenanBuff.Entities.Context
{
    public class KeenanBuffContextFactory : IKeenanBuffContextFactory
    {
        public IKeenanBuffContext Build()
        {
            return new KeenanBuffContext();
        }
    }
}
