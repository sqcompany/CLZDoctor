using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace WX.Domain
{
    public class Util
    {
        private static string CharSet = "UTF-8";
        //private static CookieContainer cc = new CookieContainer();
        public static string POST(string url, string Referer)
        {
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            req.AllowAutoRedirect = true;
            req.Referer = Referer;
            req.Method = "POST";
           //req.CookieContainer = cc;
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            using (StreamReader Sr = new StreamReader(resp.GetResponseStream(), Encoding.GetEncoding(CharSet)))
            {
                return Sr.ReadToEnd();
            }
        }
        public static string POST(string url, string Referer, byte[] requestBytes)
        {
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            req.AllowAutoRedirect = true;
            req.Referer = Referer;
            req.Method = "POST";
            //req.CookieContainer = cc;

            //byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(data);
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = requestBytes.Length;
            Stream requestStream = req.GetRequestStream();
            requestStream.Write(requestBytes, 0, requestBytes.Length);
            requestStream.Close();

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            using (StreamReader Sr = new StreamReader(resp.GetResponseStream(), Encoding.GetEncoding(CharSet)))
            {
                return Sr.ReadToEnd();
            }
        }
        public static string DownHtml_GB2312(string htmlurl)
        {
            HttpWebRequest req = WebRequest.Create(htmlurl) as HttpWebRequest;
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.GetEncoding("GB2312")))
            {
                return sr.ReadToEnd();
            }
        }
        public static string DownHtml_UTF8(string htmlurl)
        {
            HttpWebRequest req = WebRequest.Create(htmlurl) as HttpWebRequest;
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.GetEncoding("UTF-8")))
            {
                return sr.ReadToEnd();
            }
        }
        /// <summary>
        /// 进行解码 对中文编码成Unicode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string UnicodeDecode(string input)
        {
            string str = "";
            char[] chArray = input.ToCharArray();
            Encoding bigEndianUnicode = Encoding.BigEndianUnicode;
            for (int i = 0; i < chArray.Length; i++)
            {
                char ch = chArray[i];
                if (ch.Equals('\\'))
                {
                    i++;
                    i++;
                    char[] chArray2 = new char[4];
                    int index = 0;
                    index = 0;
                    while ((index < 4) && (i < chArray.Length))
                    {
                        chArray2[index] = chArray[i];
                        index++;
                        i++;
                    }
                    if (index == 4)
                    {
                        try
                        {
                            str = str + UnicodeCode2Str(chArray2);
                        }
                        catch (Exception)
                        {
                            str = str + @"\u";
                            for (int j = 0; j < index; j++)
                            {
                                str = str + chArray2[j];
                            }
                        }
                        i--;
                    }
                    else
                    {
                        str = str + @"\u";
                        for (int k = 0; k < index; k++)
                        {
                            str = str + chArray2[k];
                        }
                    }
                }
                else
                {
                    str = str + ch.ToString();
                }
            }
            return str;
        }
        private static string UnicodeCode2Str(char[] u4)
        {
            if (u4.Length < 4)
            {
                throw new Exception("It's not a unicode code array");
            }
            string str = "0123456789ABCDEF";
            char ch = char.ToUpper(u4[0]);
            char ch2 = char.ToUpper(u4[1]);
            char ch3 = char.ToUpper(u4[2]);
            char ch4 = char.ToUpper(u4[3]);
            int index = str.IndexOf(ch);
            int num2 = str.IndexOf(ch2);
            int num3 = str.IndexOf(ch3);
            int num4 = str.IndexOf(ch4);
            if (((index == -1) || (num2 == -1)) || ((num3 == -1) || (num4 == -1)))
            {
                throw new Exception("It's not a unicode code array");
            }
            byte num5 = (byte)(((index * 0x10) + num2) & 0xff);
            byte num6 = (byte)(((num3 * 0x10) + num4) & 0xff);
            byte[] bytes = new byte[] { num5, num6 };
            return Encoding.BigEndianUnicode.GetString(bytes);
        }
        /// <summary>
        /// 对中文编码成Unicode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string UnicodeEncode(string input)
        {
            Encoding bigEndianUnicode = Encoding.BigEndianUnicode;
            char[] chArray = input.ToCharArray();
            string str = "";
            foreach (char ch in chArray)
            {
                if (ch.Equals('\r') || ch.Equals('\n'))
                {
                    str = str + ch;
                }
                else
                {
                    byte[] bytes = bigEndianUnicode.GetBytes(new char[] { ch });
                    str = (str + @"\u") + string.Format("{0:X2}", bytes[0]) + string.Format("{0:X2}", bytes[1]);
                }
            }
            return str;
        }

        /// <summary>
        /// unix时间转换为datetime
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimeToTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// datetime转换为unixtime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
    }
}
