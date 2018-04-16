
/**
* 命名空间: NSub
*
* 功 能： N/A
* 类 名： Test
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 4/14/2018 3:08:48 PM jeffrey 初版
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
    using MSProject;
    using NSubstitute;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Test_GetStarted_GetSubstitue()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
        }

        [TestMethod]
        public void Test_GetStarted_ReturnSpecifiedValue()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2).Returns(3);

            int actual = calculator.Add(1, 2);
            Assert.AreEqual<int>(3, actual);
        }

        [TestMethod]
        public void Test_GetStarted_ReceiveSpecifiedCall()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2);

            calculator.Received().Add(1, 2);
            calculator.DidNotReceive().Add(5, 7);
        }

        [TestMethod]
        public void Test_GetStarted_SetPropertyValue()
        {
            ICalculator calculator = Substitute.For<ICalculator>();

            calculator.Mode.Returns("DEC");
            Assert.AreEqual<string>("DEC", calculator.Mode);

            calculator.Mode = "HEX";
            Assert.AreEqual<string>("HEX", calculator.Mode);
        }

        [TestMethod]
        public void Test_GetStarted_MatchArguments()
        {
            ICalculator calculator = Substitute.For<ICalculator>();

            calculator.Add(10, -5);

            calculator.Received().Add(10, Arg.Any<int>());
            calculator.Received().Add(Arg.Is<int>(x => x == 10), Arg.Is<int>(x => x < 0));
        }

        [TestMethod]
        public void Test_GetStarted_PassFuncToReturns()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator
               .Add(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
               .Returns(x => (int)x[0] + (int)x[1] + (int)x[2]);

            int actual = calculator.Add(5, 10, 15);

            Assert.AreEqual<int>(30, actual);
        }

        [TestMethod]
        public void Test_GetStarted_MultipleValues()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Mode.Returns("HEX", "DEC", "BIN");

            Assert.AreEqual<string>("HEX", calculator.Mode);
            Assert.AreEqual<string>("DEC", calculator.Mode);
            Assert.AreEqual<string>("BIN", calculator.Mode);
        }

        [TestMethod]
        public void Test_GetStarted_RaiseEvents()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            bool eventWasRaised = false;

            calculator.PoweringUp += (sender, args) =>
            {
                eventWasRaised = true;
            };

            calculator.PoweringUp += Raise.Event();

            Assert.IsTrue(eventWasRaised);
        }
    }
}
