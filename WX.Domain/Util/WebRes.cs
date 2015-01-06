using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace WX.Domain
{
    public class WebRes
    {
        public static EClientReply GetWeather(EClientReply clientReply)
        {
            int day = 0;
            
            string cityname = clientReply.Content;

            if (cityname.Contains("明天"))
            { day = 1; cityname = cityname.Replace("明天", ""); }
            if (cityname.Contains("后天"))
            { day = 2; cityname = cityname.Replace("后天", ""); }
            if (cityname.Contains("大后天"))
            { day = 3; cityname = cityname.Replace("大后天", ""); }
            if (cityname.Contains("大大后天"))
            { day = 4; cityname = cityname.Replace("大大后天", ""); }

            string url = "http://php.weather.sina.com.cn/xml.php?city={0}&password=DJOYnieT8234jlsK&day={1}";

            string xmlstr = Util.DownHtml_UTF8(string.Format(url, HttpUtility.UrlEncode(cityname, Encoding.GetEncoding("GB2312")), day));
            StringBuilder info = new StringBuilder();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlstr);
            XmlNode isExites = xmldoc.SelectSingleNode("Profiles");

            if (string.IsNullOrEmpty( isExites.InnerText))
            {
                clientReply.Content = string.Format(Config.ErrorWeatherMsg, cityname);
                return clientReply;
            }

            XmlNode savedate_life = xmldoc.SelectSingleNode("Profiles/Weather/savedate_life");
            XmlNode city = xmldoc.SelectSingleNode("Profiles/Weather/city");
            XmlNode status1 = xmldoc.SelectSingleNode("Profiles/Weather/status1");
            XmlNode direction1 = xmldoc.SelectSingleNode("Profiles/Weather/direction1");
            XmlNode power1 = xmldoc.SelectSingleNode("Profiles/Weather/power1");
            XmlNode temperature1 = xmldoc.SelectSingleNode("Profiles/Weather/temperature1");

            XmlNode status2 = xmldoc.SelectSingleNode("Profiles/Weather/status2");
            XmlNode direction2 = xmldoc.SelectSingleNode("Profiles/Weather/direction2");
            XmlNode power2 = xmldoc.SelectSingleNode("Profiles/Weather/power2");
            XmlNode temperature2 = xmldoc.SelectSingleNode("Profiles/Weather/temperature2");

            XmlNode chy_shuoming = xmldoc.SelectSingleNode("Profiles/Weather/chy_shuoming");
            XmlNode zwx_l = xmldoc.SelectSingleNode("Profiles/Weather/zwx_l");
            XmlNode pollution_l = xmldoc.SelectSingleNode("Profiles/Weather/pollution_l");
            XmlNode xcz_s = xmldoc.SelectSingleNode("Profiles/Weather/xcz_s");
            XmlNode gm_l = xmldoc.SelectSingleNode("Profiles/Weather/gm_l");
            XmlNode yd_s = xmldoc.SelectSingleNode("Profiles/Weather/yd_s");
            //  info.Append(cityname+"\n");
            info.Append("【" + city.InnerText + "】" + savedate_life.InnerText + "\n");
            info.Append("白天：" + status1.InnerText);
            info.Append("\n风向：" + direction1.InnerText);
            info.Append("，风级：" + power1.InnerText + "级");
            info.Append("，气温：" + temperature1.InnerText + "度\n");

            info.Append("夜间：" + status2.InnerText);
            info.Append("\n风向：" + direction2.InnerText);
            info.Append("，风级：" + power2.InnerText + "级");
            info.Append("，气温：" + temperature2.InnerText + "度\n");

            info.Append("\n感冒：" + gm_l.InnerText);
            info.Append("\n紫外线：" + zwx_l.InnerText);
            info.Append("\n空气质量：" + pollution_l.InnerText);
            info.Append("\n洗车说明：" + xcz_s.InnerText);
            info.Append("\n运动说明：" + yd_s.InnerText);

            clientReply.Content = info.ToString();
            return clientReply;
        }
    }
}
