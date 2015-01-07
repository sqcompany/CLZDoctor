using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace WX.Domain
{
    public class CacheHelper
    {
        public static void AddUserMsgCache(string UserName, string CacheMsg)
        {
            string key = "msg_" + UserName;
            DataCache.SetCache(key, CacheMsg);
        }
        public static void AddUserMsgCache(EClientReply clientReply)
        {
            string key = "msg_" + clientReply.FromUserName;
            DataCache.SetCache(key, clientReply.EventKey);
        }

        public static string GetUserMsgCache(EClientReply clientReply)
        {
            string key = "msg_" + clientReply.FromUserName;
            try
            {
                object cache = DataCache.GetCache(key).ToString();
                if (string.IsNullOrEmpty(cache.ToString()))
                    return string.Empty;
                else
                    return cache.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string GetUserMsgCache(string UserName)
        {
            string key = "msg_" + UserName;
            try
            {
                object cache = DataCache.GetCache(key).ToString();
                if (string.IsNullOrEmpty(cache.ToString()))
                    return string.Empty;
                else
                    return cache.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 缓存操作类
        /// </summary>
        public class DataCache
        {
            /// <summary>
            /// 获取当前应用程序指定CacheKey的Cache值
            /// </summary>
            /// <param name="CacheKey"></param>
            /// <returns></returns>
            public static object GetCache(string CacheKey)
            {
                System.Web.Caching.Cache objCache = HttpRuntime.Cache;
                return objCache[CacheKey];
            }

            /// <summary>
            /// 设置当前应用程序指定CacheKey的Cache值
            /// </summary>
            /// <param name="CacheKey"></param>
            /// <param name="objObject"></param>
            public static void SetCache(string CacheKey, object objObject)
            {
                System.Web.Caching.Cache objCache = HttpRuntime.Cache;

                objCache.Insert(CacheKey, objObject);
            }

            public static void RomoveCache(string CacheKey)
            {
                System.Web.Caching.Cache objCache = HttpRuntime.Cache;
                objCache.Remove(CacheKey);
            }
        }
    }
}
