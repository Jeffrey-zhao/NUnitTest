﻿
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

namespace Manulife.LogAn.Lib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FakeLogger : ILogger
    {
        public string LastError;

        public string TestFlag
        {
            get;set;
        }

        public void LogError(string message)
        {
            LastError = message;
        }
    }
}
