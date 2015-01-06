using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Domain
{
    public class EventHandel
    {
        /// <summary>
        /// 菜单事件返回内容
        /// </summary>
        /// <param name="clientReply">回复实体</param>
        /// <param name="IsAnswer">false 返回菜单提示，true返回结果</param>
        /// <returns></returns>
        public static EClientReply Operator(EClientReply clientReply, bool IsAnswer)
        {
            switch (clientReply.EventKey)
            {
                case "Event_Weather_Click":
                    if (IsAnswer)
                    {
                        clientReply = WebRes.GetWeather(clientReply);
                    }
                    else
                    {
                        CacheHelper.AddUserMsgCache(clientReply);//添加缓存
                        clientReply.Content = "请输入要查询天气的城市名称";
                    }
                    break;

            }
            return clientReply;
        }
    }
}
