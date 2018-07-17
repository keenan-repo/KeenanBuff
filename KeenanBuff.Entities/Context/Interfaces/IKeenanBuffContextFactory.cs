using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeenanBuff.Entities.Context.Interfaces
{
    interface IKeenanBuffContextFactory
    {
        IKeenanBuffContext Build();
    }
}
