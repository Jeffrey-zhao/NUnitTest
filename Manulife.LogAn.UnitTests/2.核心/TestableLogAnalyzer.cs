using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manulife.LogAn.Lib
{
    public class TestableLogAnalyzer : LogAnalyzerUsingFactoryMethod
    {
        public IExtensionManager manager;
        public TestableLogAnalyzer(IExtensionManager manager)
        {
            this.manager = manager;
        }

        protected override IExtensionManager GetManager()
        {
            return this.manager;
        }
    }
}
