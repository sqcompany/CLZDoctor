using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Domain.Entity
{
    public class EReplyPicText : EBase
    {
        public string MsgType { get { return "news"; } }
        public int ArticleCount { get; set; }
        /// <summary>
        /// 多条图文消息信息，默认第一个item为大图 
        /// </summary>
        public List<Item> Articles { get; set; }

        public struct Item
        {
            /// <summary>
            ///  	图文消息标题 
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            ///  	图文消息描述 
            /// </summary>
            public string Description { get; set; }
            /// <summary>
            /// 图片链接，支持JPG、PNG格式，较好的效果为大图640*320，小图80*80。 
            /// </summary>
            public string PicUrl { get; set; }
            /// <summary>
            /// 点击图文消息跳转链接 
            /// </summary>
            public string Url { get; set; }
        }

        public string ToString()
        {
            string text = @"<xml>
                                   <ToUserName><![CDATA[{0}]]></ToUserName>
                                   <FromUserName><![CDATA[{1}]]></FromUserName>
                                   <CreateTime>{2}</CreateTime>
                                   <MsgType><![CDATA[{3}]]></MsgType>
                                   <ArticleCount>{4}</ArticleCount>
                                   <Articles>{5}</Articles>
                                   <FuncFlag>{6}</FuncFlag>
                                   </xml>";
            string article = @"<item>
                                    <Title><![CDATA[{0}]]></Title>
                                    <Description><![CDATA[{0}]]></Description>
                                    <PicUrl><![CDATA[{1}]]></PicUrl>
                                    <Url><![CDATA[{2}]]></Url>
                                    </item>";
            StringBuilder sb = new StringBuilder();
            foreach (Item item in Articles)
            {
                sb.Append(string.Format(article, item.Title, item.Description, item.PicUrl, item.Url));
            }

            return string.Format(text, this.ToUserName, this.FromUserName, this.CreateTime, this.MsgType, Articles.Count, sb.ToString(), this.FuncFlag);
        }
    }
}
