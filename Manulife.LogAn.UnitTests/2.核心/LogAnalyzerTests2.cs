using Manulife.LogAn.Lib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 2.Unit Test 核心
/// 存根Stub --当你依赖的对象无法控制，可通过存根来解决
/// 1) 外部依赖：与测试代码交互的对象，但无法控制它,如文件系统，线程，内存，时间等
/// 2) 存根：对外部依赖项的可控制的替代物
/// 3) A型--把具体类抽象成接口或者委托
///    B型--代码重构，依赖注入DI-构造注入/属性注入
/// 4) 抽取和重写
/// 模拟对象
/// 隔离框架
/// </summary>
namespace Manulife.LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests2
    {
        [Test]
        public void IsValidFileName_NameSupportExtension_ReturnsTrue()
        {
            //准备一个存根
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillBeValid = true;
            //通过构造器注入传入存根

            LogAnalyzer2 analyzer = new LogAnalyzer2(myFakeManager);
            bool result = analyzer.IsValidLogFileName("short.ext");

            Assert.AreEqual(true, result);
        }

        [Test]
        public void OverrideTest()
        {
            FakeExtensionManager stub = new FakeExtensionManager();
            stub.WillBeValid = true;
            // 创建被测试类的派生类的实例
            TestableLogAnalyzer logan = new TestableLogAnalyzer(stub);
            bool result = logan.IsValidLogFileName("stubfile.ext");

            Assert.AreEqual(true, result);
        }
        // 定义一个最简单的存根
        internal class FakeExtensionManager : IExtensionManager
        {
            public bool WillBeValid = false;
            public bool IsValid(string fileName)
            {
                return WillBeValid;
            }
        }
    }
}
