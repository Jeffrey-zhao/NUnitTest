using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manulife.LogAn.Lib
{
    public class LogAnalyzerUsingFactoryMethod
    {
        public bool IsValidLogFileName(string fileName)
        {
            //use virtual method
            return GetManager().IsValid(fileName);
        }

        protected virtual IExtensionManager GetManager()
        {
            //hard code
            return new FileExtensionManager();
        }
    }
}
