using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WX.Domain
{
    public class AdapterReply
    {
        XmlDocument xmldoc = null;
        EClientReply _clientReply=null;
        public AdapterReply(string userSendXml)
        {
            xmldoc = new XmlDocument();
            xmldoc.LoadXml(userSendXml);
        }

        public AdapterReply(EClientReply clientReply)
        {
            _clientReply = clientReply;
        }

        public EClientReply ToClientReply()
        {
            EClientReply ec = new EClientReply();

            XmlNode FromUserName = xmldoc.SelectSingleNode("xml/FromUserName");
            if (FromUserName != null)
            {
                ec.FromUserName = FromUserName.InnerText.Trim();
            }

            XmlNode ToUserName = xmldoc.SelectSingleNode("xml/ToUserName");
            if (ToUserName != null)
            {
                ec.ToUserName = ToUserName.InnerText.Trim();
            }

            XmlNode Content = xmldoc.SelectSingleNode("xml/Content");
            if (Content != null)
            {
                ec.Content = Content.InnerText.Trim();
            }

            XmlNode MsgType = xmldoc.SelectSingleNode("xml/MsgType");
            if (MsgType != null)
            {
                switch (MsgType.InnerText.Trim())
                {
                    case "text": ec.MsgType = EnmuMsgType.Text; break;
                    case "event": ec.MsgType = EnmuMsgType.Event; break;
                    case "location": ec.MsgType = EnmuMsgType.Location; break;
                }
            }
            XmlNode EventKey = xmldoc.SelectSingleNode("xml/EventKey");
            if (EventKey != null)
            {
                ec.EventKey = EventKey.InnerText.Trim();
            }

            XmlNode Event = xmldoc.SelectSingleNode("xml/Event");
            if (Event != null)
            {
                switch (Event.InnerText.Trim().ToLower())
                {
                    case "subscribe": ec.Event = EnmuEvent.Subscribe; break;
                    case "click": ec.Event = EnmuEvent.Click; break;
                }
            }

            XmlNode Location_X = xmldoc.SelectSingleNode("xml/Location_X");
            if (Location_X != null)
            {
                ec.Location_X = Location_X.InnerText.Trim();
            }
            XmlNode Location_Y = xmldoc.SelectSingleNode("xml/Location_Y");
            if (Location_Y != null)
            {
                ec.Location_Y = Location_Y.InnerText.Trim();
            }
            XmlNode Label = xmldoc.SelectSingleNode("xml/Label");
            if (Label != null)
            {
                ec.Label = Label.InnerText.Trim();
            }

            XmlNode Scale = xmldoc.SelectSingleNode("xml/Scale");
            if (Scale != null)
            {
                ec.Scale = Scale.InnerText.Trim();
            }

            return ec;
        }

        public string ToReplyText()
        { 
            EReplyText er = new EReplyText();
            er.FromUserName = _clientReply.FromUserName;
            er.ToUserName = _clientReply.ToUserName;
            er.Content = _clientReply.Content;
            return er.ToString();
        }
        public EReplyText ToReply()
        {
            EReplyText er = new EReplyText();
            er.FromUserName = _clientReply.FromUserName;
            er.ToUserName = _clientReply.ToUserName;
            er.Content = _clientReply.Content;
            return er;
        }
    }
}
