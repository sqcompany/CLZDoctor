using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Domain
{
    public class EBase
    {
        /// <summary>
        /// 接收方帐号（收到的OpenID） 
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        ///  	开发者微信号 
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        ///  	消息创建时间 
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        ///  	位0x0001被标志时，星标刚收到的消息。 
        /// </summary>
        public string FuncFlag { get; set; }
        /// <summary>
        ///  消息id，64位整型 
        /// </summary>
        public string MsgId { get; set; }
    }
}
