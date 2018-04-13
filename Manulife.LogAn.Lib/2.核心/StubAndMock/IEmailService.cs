
/**
* 命名空间: Manulife.LogAn.Lib._2.核心.StubAndMock
*
* 功 能： N/A
* 类 名： IEmailService
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 4/13/2018 11:38:26 PM jeffrey 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：*****有限公司 　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Manulife.LogAn.Lib.StubAndMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IEmailService
    {
        void SendEmail(EmailInfo emailInfo);
    }

    public class EmailInfo
    {
        public string Body;
        public string To;
        public string Subject;

        public EmailInfo(string to, string subject, string body)
        {
            this.To = to;
            this.Subject = subject;
            this.Body = body;
        }

        public override bool Equals(object obj)
        {
            EmailInfo compared = obj as EmailInfo;

            return To == compared.To && Subject == compared.Subject
                && Body == compared.Body;
        }
    }
}
