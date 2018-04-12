using Manulife.LogAn.Lib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 1.Unit Test 入门
/// MS Test Attribute	    NUnit Attribute	        用途
/// [TestClass]	            [TestFixture]	        定义一个测试类，里面可以包含很多测试函数和初始化、销毁函数（以下所有标签和其他断言）。
/// [TestMethod]	        [Test]	                定义一个独立的测试函数。
/// [ClassInitialize]	    [TestFixtureSetUp]	    定义一个测试类初始化函数，每当运行测试类中的一个或多个测试函数时，这个函数将会在测试函数被调用前被调用一次（在第一个测试函数运行前会被调用）。
/// [ClassCleanup]	        [TestFixtureTearDown]	定义一个测试类销毁函数，每当测试类中的选中的测试函数全部运行结束后运行（在最后一个测试函数运行结束后运行）。
/// [TestInitialize]	    [SetUp]	                定义测试函数初始化函数，每个测试函数运行前都会被调用一次。
/// [TestCleanup]	        [TearDown]	            定义测试函数销毁函数，每个测试函数执行完后都会被调用一次。
/// [AssemblyInitialize]	--	                    定义测试Assembly初始化函数，每当这个Assembly中的有测试函数被运行前，会被调用一次（在Assembly中第一个测试函数运行前会被调用）。
/// [AssemblyCleanup]	    --	                    定义测试Assembly销毁函数，当Assembly中所有测试函数运行结束后，运行一次。（在Assembly中所有测试函数运行结束后被调用）
/// [DescriptionAttribute]	[Category]	            定义标识分组。
/// </summary>
namespace Manulife.LogAn.UnitTests
{
    /// <summary>
    /// 测试案例的主要内容
    /// 1.TestFixture,Test
    /// 2.TestCase
    /// 3.SetUp/TearDown
    /// 4.object factory
    /// 5.coverage test
    /// 6.Ignore
    /// 7.Category --now not know how to use
    /// 8.Test Property -- Test situation where status of system changed
    /// </summary>
    [TestFixture()]
    public class LogAnalyzerTests1
    {
        private LogAnalyzer1 analyzer = null;

        [SetUp]
        public void Setup()
        {
            analyzer = new LogAnalyzer1();//construct
        }
        [Test()]
        [Category("Fast Tests")]
        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            analyzer = LogAnalyzerFactory.MakeAnalyzer();// object factory
            bool result = analyzer.IsValidLogFileName("filename.foo");
            Assert.AreEqual(false, result);
        }

        [Test()]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            bool result = analyzer.IsValidLogFileName("filename.SLF");
            Assert.AreEqual(true, result);
        }

        [Test()]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            bool result = analyzer.IsValidLogFileName("filename.slf");
            Assert.AreEqual(true, result);
        }

        [TestCase("filename1.slf")]
        [TestCase("filename2.SLF")]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string fileName)
        {
            bool result = analyzer.IsValidLogFileName(fileName);
            Assert.AreEqual(true, result);
        }


        [TearDown]
        public void TearDown()
        {
            analyzer = null; //deconstruct
        }

        [Test()]
        public void IsValidLogFileName_EmptyName_Throws()
        {
            var ex = Assert.Catch<Exception>(() => analyzer.IsValidLogFileName(string.Empty));
            StringAssert.Contains("fileName has to be provided.", ex.Message);
        }

        [Test]
        [Ignore("there is a problem with this test!")]
        public void IsValidFileName_ValidFile_ReturnsTrue()
        {
            // ...
        }

        [TestCase("badfile.foo", false)]
        [TestCase("goodfile.slf", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string fileName, bool expected)
        {
            LogAnalyzer1 analyzer = new LogAnalyzer1();
            analyzer.IsValidLogFileName(fileName);
            Assert.AreEqual(expected, analyzer.WasLastFileNameValid);
        }
    }
}
