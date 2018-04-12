using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manulife.LogAn.Lib
{
    public class LogAnalyzer2
    {
        private IExtensionManager manager;
        //构造注入
        public LogAnalyzer2(IExtensionManager manager)
        {
            this.manager = manager;
        }

        //属性注入
        //如果你想表明被测试类的某个依赖项是可选的，
        //或者测试可以放心使用默认创建的这个依赖项实例，
        //这时你就可以使用属性注入。
        public LogAnalyzer2()
        {
            this.manager = new FileExtensionManager();
        }
        public IExtensionManager ExtensionManager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
            }
        }

        public bool IsValidLogFileName(string fileName)
        {
            //读取配置文件
            //如果配置文件支持这个扩展名，则返回true
            //step 1
            //FileExtensionManager manager = new FileExtensionManager();
            //step 2
            //IExtensionManager manager = new FileExtensionManager();
            return manager.IsValid(fileName);
        }
    }
}
