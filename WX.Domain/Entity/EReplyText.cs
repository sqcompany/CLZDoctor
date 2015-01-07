using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Domain
{
    public class EReplyText : EBase
    {
        public string MsgType { get { return "text"; } }
        public string Content { get; set; }

        public string ToString()
        {
            string text = @"<xml>
                <ToUserName><![CDATA[{0}]]></ToUserName>
                <FromUserName><![CDATA[{1}]]></FromUserName>
                <CreateTime>{2}</CreateTime>
                <MsgType><![CDATA[{3}]]></MsgType>
                <Content><![CDATA[{4}]]></Content>
               <FuncFlag>{5}</FuncFlag>
                </xml>";

            return string.Format(text, this.FromUserName, this.ToUserName, this.CreateTime, this.MsgType, this.Content, this.FuncFlag);
        }
    }
}
