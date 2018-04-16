
/**
* 命名空间: NSub
*
* 功 能： N/A
* 类 名： Test4
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 4/14/2018 3:56:19 PM jeffrey 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：*****有限公司 　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace NSub
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NSubstitute;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class Test4
    {
        public interface ICalculator
        {
            int Add(int a, int b);
            string Mode { get; set; }
        }

        [TestMethod]
        public void Test_ReturnForSpecificArgs_UseArgumentsMatcher()
        {
            var calculator = Substitute.For<ICalculator>();

            // 当第一个参数是任意int类型的值，第二个参数是5时返回。
            calculator.Add(Arg.Any<int>(), 5).Returns(10);
            Assert.AreEqual(10, calculator.Add(123, 5));
            Assert.AreEqual(10, calculator.Add(-9, 5));
            Assert.AreNotEqual(10, calculator.Add(-9, -9));

            // 当第一个参数是1，第二个参数小于0时返回。
            calculator.Add(1, Arg.Is<int>(x => x < 0)).Returns(345);
            Assert.AreEqual(345, calculator.Add(1, -2));
            Assert.AreNotEqual(345, calculator.Add(1, 2));

            // 当两个参数都为0时返回。
            calculator.Add(Arg.Is(0), Arg.Is(0)).Returns(99);
            Assert.AreEqual(99, calculator.Add(0, 0));
        }

        [TestMethod]
        public void Test_CheckReceivedCalls_CheckingCallsToPropeties()
        {
            var calculator = Substitute.For<ICalculator>();

            var mode = calculator.Mode;
            calculator.Mode = "TEST";

            // 检查接收到了对属性 getter 的调用
            // 这里需要使用临时变量以通过编译
            var temp = calculator.Received().Mode;

            // 检查接收到了对属性 setter 的调用，参数为"TEST"
            calculator.Received().Mode = "TEST";
        }
    }
}
