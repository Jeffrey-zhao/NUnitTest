
/**
* 命名空间: Manulife.LogAn.UnitTests._2.核心.NSub
*
* 功 能： N/A
* 类 名： ILogger
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 4/16/2018 10:15:28 PM jeffrey 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：*****有限公司 　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Manulife.LogAn.UnitTests
{
    using Lib;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NSubstitute;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class LogAnalyzerTest6
    {
        [TestMethod]
        public void Analyze_TooShortFileName_CallLogger()
        {
            ILogger logger = Substitute.For<ILogger>();
            LogAnalyzer5 analyzer5 = new LogAnalyzer5(logger);
            analyzer5.MinNameLength = 6;
            analyzer5.Analyze("a.txt");
            var ret = "";
            logger.TestFlag.Returns(x=> { ret = "Test"; return ret; });
            logger.Received().LogError("too short");
            Assert.AreEqual(logger.TestFlag, ret);
        }
    }
}
