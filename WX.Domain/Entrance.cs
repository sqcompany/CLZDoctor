using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using WX.Domain;

namespace WX.Domain
{
    public class Entrance
    {
        private const string Token = "zhengsheng";//token

        public static void Handle()//进入处理
        {
            using (Stream s = System.Web.HttpContext.Current.Request.InputStream)
            {
                byte[] b = new byte[s.Length];
                s.Read(b, 0, (int)s.Length);
                string postStr = Encoding.UTF8.GetString(b);
                if (!string.IsNullOrEmpty(postStr))
                {
                    PassHandle(postStr);//得到用户输入信息
                }
            }
        }

        public static void FirstValid()
        {
            if (!string.IsNullOrEmpty(GetRequestString("echoStr")))
            {
                string echoStr = GetRequestString("echoStr");
                if (CheckSignature())
                {
                    if (!string.IsNullOrEmpty(echoStr))
                    {
                        ResponseEnd(echoStr);
                    }
                }
            }
            else
            {
                Handle();
            }
        }
        private static bool CheckSignature()
        {
            string signature = GetRequestString("signature");
            string timestamp = GetRequestString("timestamp");
            string nonce = GetRequestString("nonce");
            string[] ArrTmp = { Token, timestamp, nonce };
            Array.Sort(ArrTmp);     //字典排序
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();
            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void PassHandle(string userSendXml)
        {
            AdapterReply adpClientReply = new AdapterReply(userSendXml);
            EClientReply clientReply = adpClientReply.ToClientReply();

            //转换及处理的用户信息处理
            switch (clientReply.MsgType)
            {
                case EnmuMsgType.Text: clientReply = TxtHandle(clientReply); break;
                case EnmuMsgType.Event: clientReply = EventHandle(clientReply); break;
            }

            if (string.IsNullOrEmpty(clientReply.Content))
                ResponseEnd(clientReply.ToReplyText());//回复给用户
        }

        public static EClientReply TxtHandle(EClientReply clientReply)
        {
            if (string.IsNullOrEmpty(clientReply.Content))
            {
                clientReply.Content = Config.ErrorMsg;
                return clientReply;
            }
            else
            {
                clientReply.EventKey = CacheHelper.GetUserMsgCache(clientReply.FromUserName);
                return EventHandel.Operator(clientReply, true); //根据缓存值返回相应的内容
            }
        }

        public static EClientReply EventHandle(EClientReply clientReply)
        {
            switch (clientReply.Event)
            {
                case EnmuEvent.Subscribe:
                    clientReply.Content = Config.WelcomeMsg;
                    break;

                case EnmuEvent.Click:
                    clientReply = EventHandel.Operator(clientReply, false);
                    break;

                default: clientReply.Content = Config.ErrorMsg;
                    break;
            }

            return clientReply;
        }

        public static string GetRequestString(string name)
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request[name]))
            {
                return HttpContext.Current.Request[name];
            }
            return string.Empty;
        }

        public static void ResponseEnd(string msg)
        {
            HttpContext.Current.Response.Write(msg);
            HttpContext.Current.Response.End();
        }
    }
}