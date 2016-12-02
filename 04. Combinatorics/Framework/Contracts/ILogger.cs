using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Contracts
{
    public interface ILogger
    {
        void Write(string text);

        void WriteLine();

        void WriteLine(string text);
    }
}
