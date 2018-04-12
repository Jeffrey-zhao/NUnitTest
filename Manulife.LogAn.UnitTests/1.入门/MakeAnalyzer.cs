using Manulife.LogAn.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manulife.LogAn.UnitTests
{
    public static class LogAnalyzerFactory
    {
        public static LogAnalyzer1 MakeAnalyzer()
        {
            return new LogAnalyzer1();
        }
    }
}
