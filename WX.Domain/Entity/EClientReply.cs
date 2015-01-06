using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Domain
{
    public class EClientReply
    {
        public string ToUserName { get; set; }

        public string FromUserName { get; set; }

        public string Content { get; set; }

        public EnmuMsgType MsgType { get; set; }

        public string EventKey { get; set; }

        public EnmuEvent Event { get; set; }

        public string Location_X { get; set; }//地理位置纬度
        public string Location_Y { get; set; }//地理位置纬度
        public string Label { get; set; }//地理位置信息
        public string Scale { get; set; }//地图缩放大小
        public string ToReplyText()
        {
            string text = @"<xml>
                <ToUserName><![CDATA[{0}]]></ToUserName>
                <FromUserName><![CDATA[{1}]]></FromUserName>
                <Content><![CDATA[{2}]]></Content>
                </xml>";
            return string.Format(text, this.FromUserName, this.ToUserName,  this.Content);
        }
    }
}
