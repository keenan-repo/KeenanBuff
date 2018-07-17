using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeenanBuff.Common.Logger.Interfaces
{
    public interface IFileLogger
    {
        void Log(string message);
        void Error(string message);
    }
}
