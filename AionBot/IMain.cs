using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionBot
{
    public interface IMain
    {
        void setLog(string text, bool isError);
        void setGameWindow();
    }
}
