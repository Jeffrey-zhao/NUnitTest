
/**
* 命名空间: Manulife.LogAn.Lib._2.核心.Mock
*
* 功 能： N/A
* 类 名： IService
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 4/13/2018 10:49:29 PM jeffrey 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：*****有限公司 　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Manulife.LogAn.Lib.Mock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FakeWebService: IWebService
    {
        public string LastError;
        public void LogError(string message)
        {
            this.LastError = message;
        }
    }
}
