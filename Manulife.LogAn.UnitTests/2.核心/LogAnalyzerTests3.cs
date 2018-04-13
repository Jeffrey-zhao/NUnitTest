
/**
* 命名空间: Manulife.LogAn.UnitTests._2.核心
*
* 功 能： N/A
* 类 名： LogAnalyzerTests3
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 4/13/2018 11:17:30 PM jeffrey 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：*****有限公司 　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Manulife.LogAn.UnitTests
{
    using Lib.Mock;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class LogAnalyzerTests3
    {
        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            FakeWebService mockService = new FakeWebService();
            LogAnalyzer3 log = new LogAnalyzer3(mockService);

            string tooShortFileName = "abc.ext";
            log.Analyze(tooShortFileName);
            StringAssert.Contains("FileName is too short : abc.ext", mockService.LastError);
        }
        
    }
}
