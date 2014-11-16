using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLZDoctor.Domain;
using CLZDoctor.Entities;
using Ninject;
using DomainModule = GrabData.Domain.DomainModule;

namespace GrabData
{
    public partial class Form1 : Form
    {

        private readonly static IKernel Kernel = new StandardKernel(new DomainModule());
        public Form1()
        {
            InitializeComponent();
        }
        private string zhyizm = "OZ";
        private void btn_grab_Click(object sender, EventArgs e)
        {
            var instance = Kernel.Get<IGrabDataRepo>();
            var list = instance.Select(318);

            foreach (var grabData in list)
            {
                try
                {
                    var fj = GetZhzyFj(grabData.Url, grabData.Name);
                    InsertToDataFj(fj);
                    instance.UpdateState(grabData.Id, 2);
                }
                catch (Exception)
                {
                    instance.UpdateState(grabData.Id, 0);
                }
            }


            
            MessageBox.Show("保存成功！");
            //const string baseUrl = "http://www.zhzyw.org/";
            //var py = zhyizm.ToCharArray();
            //foreach (var p in py)
            //{
            //    var result = GetPyPageUrl(p.ToString());
            //    foreach (var i in result)
            //    {
            //        var res = GetZhzyFjUrl(i.Key, i.Value == 0 ? 1 : i.Value);
            //        foreach (var re in res)
            //        {
            //            Kernel.Get<IGrabDataCore>().Add(new CLZDoctor.Entities.GrabData { Name = re.Key, Url = baseUrl + re.Value, State = 1 });
            //        }
            //    }
            //}

            //抓去O
            //var res = GetZhzyFjUrl("K", 4, 3);
            //bool state = false;
            //foreach (var re in res)
            //{
            //    if (re.Key.Equals("宽中沉参散"))
            //    {
            //        state = true;
            //        continue;
            //    }
            //    if (state)
            //        Kernel.Get<IGrabDataCore>().Add(new CLZDoctor.Entities.GrabData { Name = re.Key, Url = baseUrl + re.Value, State = 1 });
            //}
            //foreach (var i in result)
            //{
            //    var res = GetZhzyFjUrl(i.Key, i.Value == 0 ? 1 : i.Value);
            //    foreach (var re in res)
            //    {
            //        try
            //        {
            //            var fj = GetZhzyFj(re.Value, re.Key);
            //            var task = new Task(InsertToDataFj, fj);
            //            task.Start();
            //        }
            //        catch
            //        {
            //            Kernel.Get<IGrabDataCore>().Add(new CLZDoctor.Entities.GrabData { Name = re.Key, Url = re.Value });
            //        }

            //    }
            //}
            //var baseUrl = "http://www.cn939.com/";
            //var urls = GetFjUrl();
            //var fyurls = GetFyFj();
            //foreach (var url in fyurls)
            //{
            //    var fj = GetFj(baseUrl + url.Value, "UTF-8");
            //    var pr = new Prescription
            //    {
            //        Name = fj.ContainsKey("名称") ? fj["名称"] : "",
            //        Alias = fj.ContainsKey("别名") ? fj["别名"] : "",
            //        Type = fj.ContainsKey("分类") ? fj["分类"] : "",
            //        MakeUp = fj.ContainsKey("组成") ? fj["组成"] : "",
            //        Usage = fj.ContainsKey("用法") ? fj["用法"] : "",
            //        Effect = fj.ContainsKey("功效") ? fj["功效"] : "",
            //        Explain = fj.ContainsKey("方解") ? fj["方解"] : "",
            //        FangGe = fj.ContainsKey("方歌") ? fj["方歌"] : "",
            //        Notes = fj.ContainsKey("注意事项") ? fj["注意事项"] : "",
            //        Related = fj.ContainsKey("相关症状") ? fj["相关症状"] : "",
            //        Similar = fj.ContainsKey("同类方剂") ? fj["同类方剂"] : "",
            //        Source = ""
            //    };
            //    int id = Kernel.Get<IPrescriptionCore>().Insert(pr);
            //}
        }


        private static void InsertToDataFj(object fj)
        {
            foreach (Dictionary<string, string> dictionary in fj as List<Dictionary<string, string>>)
            {
                var remark = string.Empty;
                if (dictionary.ContainsKey("制法"))
                    remark = dictionary["制法"];
                else if (dictionary.ContainsKey("炮制"))
                    remark = dictionary["炮制"];
                var pr = new Prescription
                {
                    Name = dictionary.ContainsKey("名称") ? dictionary["名称"] : "",
                    Alias = dictionary.ContainsKey("别名") ? dictionary["别名"] : "",
                    MakeUp = dictionary.ContainsKey("处方") ? dictionary["处方"] : "",
                    Effect = dictionary.ContainsKey("功能主治") ? dictionary["功能主治"] : "",
                    Usage = dictionary.ContainsKey("用法用量") ? dictionary["用法用量"] : "",
                    Remark = remark,
                    Source = dictionary.ContainsKey("摘录") ? dictionary["摘录"] : "",
                    Notes = dictionary.ContainsKey("注意") ? dictionary["注意"] : ""
                };
                int id = Kernel.Get<IPrescriptionCore>().Insert(pr);
            }
        }

        private Dictionary<string, string> GetFjUrl()
        {
            var baseUrl = "http://www.cn939.com/";
            var fl = new Dictionary<string, string>();
            const string baseUrlLetter = "http://www.cn939.com/fangji/letter-";
            var suffix = ".html";
            const string strAB = "ABCDEFGHJKLMNOPQRSTWXYZ";
            var strA = strAB.ToCharArray();
            var pattern = "<div.*(?=content_t)(.|\n)*?</div>";
            var reg = new Regex(pattern, RegexOptions.IgnoreCase);
            var patterns = @"<a\s*href=(""|')(?<href>[\s\S.]*?)(""|').*?>\s*(?<name>[\s\S.]*?)</a>";
            var regs = new Regex(patterns, RegexOptions.IgnoreCase);
            var patternFj = "<div.*(?=Zoom)(.|\n)*?</div>";
            var regfj = new Regex(patternFj, RegexOptions.IgnoreCase);
            var patterncont = @"<dd><strong>(?<tag>[\s\S.]*?)</strong>\s*(?<cont>[\s\S.]*?)</dd>";
            var regcont = new Regex(patterncont, RegexOptions.IgnoreCase);
            var strb = new StringBuilder();
            foreach (var ab in strA)
            {
                var strHtml = GetWebContent(baseUrlLetter + ab + suffix, "UTF-8");

                MatchCollection mc = reg.Matches(strHtml);
                if (mc.Count > 0)
                {
                    foreach (Match item in mc)
                    {
                        MatchCollection mcs = regs.Matches(item.Groups[0].Value);
                        if (mcs.Count > 0)
                        {
                            foreach (Match mc1 in mcs)
                            {
                                if (!fl.ContainsKey(mc1.Groups["name"].Value))
                                    fl.Add(mc1.Groups["name"].Value, mc1.Groups["href"].Value);
                            }
                        }
                    }
                }
            }
            return fl;
        }
        /// <summary>
        /// 抓去分页数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetFyFj()
        {
            var fl = new Dictionary<string, string>();
            var baseUrl = "http://www.cn939.com/";
            var pattern = "<div.*(?=content_t)(.|\n)*?</div>";
            var reg = new Regex(pattern, RegexOptions.IgnoreCase);
            var patterns = @"<a\s*href=(""|')(?<href>[\s\S.]*?)(""|').*?>\s*(?<name>[\s\S.]*?)</a>";
            var regs = new Regex(patterns, RegexOptions.IgnoreCase);
            var list = new string[] { "/fangji/letter-D-2.html", "/fangji/letter-S-2.html", "/fangji/letter-Z-2.html" };
            for (int i = 0; i < list.Count(); i++)
            {
                var strHtml = GetWebContent(baseUrl + list[i], "UTF-8");

                MatchCollection mc = reg.Matches(strHtml);
                if (mc.Count > 0)
                {
                    foreach (Match item in mc)
                    {
                        MatchCollection mcs = regs.Matches(item.Groups[0].Value);
                        if (mcs.Count > 0)
                        {
                            foreach (Match mc1 in mcs)
                            {
                                if (!fl.ContainsKey(mc1.Groups["name"].Value))
                                    fl.Add(mc1.Groups["name"].Value, mc1.Groups["href"].Value);
                            }
                        }
                    }
                }
            }
            return fl;
        }
        private Dictionary<string, string> GetFj(string url, string encode)
        {

            string strWebContent = GetWebContent(url, encode);

            int iBodyStart = strWebContent.IndexOf("<body", 0);

            int iBodyEnd = strWebContent.IndexOf("</body>", iBodyStart);

            string strWeb = strWebContent.Substring(iBodyStart, iBodyEnd - iBodyStart + 8);

            var webb = new WebBrowser();

            webb.Navigate("about:blank");

            var htmldoc = webb.Document.OpenNew(true);

            htmldoc.Write(strWeb);

            HtmlElementCollection htmldd = htmldoc.GetElementsByTagName("dd");

            var list = new Dictionary<string, string>();

            StringBuilder strb = new StringBuilder();

            foreach (HtmlElement dd in htmldd)
            {
                var name = dd.GetElementsByTagName("strong")[0].InnerText;
                list.Add(name.Replace("【", "").Replace("】", ""), dd.InnerText.Replace(name, ""));
            }
            return list;
        }



        private string GetWebContent(string url, string encode)
        {

            var request = WebRequest.Create(url);

            var response = request.GetResponse();

            var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encode));

            var strhtml = reader.ReadToEnd();

            reader.Close();

            reader.Dispose();

            response.Close();

            return strhtml;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kernel.Get<IPrescriptionCore>().SplitRecipe();
        }


        #region 中华医药



        public Dictionary<string, int> GetPyPageUrl(string item)
        {
            var result = new Dictionary<string, int>();
            var baseUrl = "http://www.zhzyw.org/zycs/zyfj/";
            var suffix = ".html";
            var pattern = "<div.*(?=pagecontent)(.|\n)*?</div>";
            var reg = new Regex(pattern, RegexOptions.IgnoreCase);

            string strWebContent = GetWebContent(baseUrl + item.ToString().ToUpper() + suffix, "gb2312");
            MatchCollection mc = reg.Matches(strWebContent);
            if (mc.Count > 0)
            {
                var strPageHtml = mc[0].Groups[0].Value;
                var webb = new WebBrowser();

                webb.Navigate("about:blank");

                var htmldoc = webb.Document.OpenNew(true);

                htmldoc.Write(strPageHtml);
                HtmlElementCollection htmldd = htmldoc.GetElementsByTagName("a");
                var lastpage = htmldd[htmldd.Count - 1];
                var href = lastpage.GetAttribute("href");
                href = href.Replace(".html", "");
                result.Add(item.ToString(), Convert.ToInt32(href.Split('_')[1]));
            }

            return result;
        }

        private Dictionary<string, string> GetZhzyFjUrl(string py, int count, int start)
        {
            var result = new Dictionary<string, string>();
            var baseUrl = "http://www.zhzyw.org/zycs/zyfj/";
            var pattern = "<div.*(?=ullist01)(.|\n)*?</div>";
            var reg = new Regex(pattern, RegexOptions.IgnoreCase);
            for (int i = start; i < count; i++)
            {
                var url = "";
                if (i == 0)
                    url = baseUrl + py.ToLower() + ".html";
                else
                    url = baseUrl + py.ToLower() + "_" + (i + 1) + ".html";
                string strWebContent = GetWebContent(url, "gb2312");
                MatchCollection mc = reg.Matches(strWebContent);
                if (mc.Count > 0)
                {
                    var strPageHtml = mc[0].Groups[0].Value;
                    var webb = new WebBrowser();

                    webb.Navigate("about:blank");

                    var htmldoc = webb.Document.OpenNew(true);

                    htmldoc.Write(strPageHtml);
                    HtmlElementCollection htmldd = htmldoc.GetElementsByTagName("a");
                    for (int j = 0; j < htmldd.Count; j++)
                    {
                        if (!result.ContainsKey(htmldd[j].InnerText))
                            result.Add(htmldd[j].InnerText, htmldd[j].GetAttribute("href").Replace("about:", ""));
                    }
                }
            }
            return result;
        }

        private List<Dictionary<string, string>> GetZhzyFj(string url, string name)
        {
            var list = new List<Dictionary<string, string>>();
            Dictionary<string, string> result = null;
            var baseUrl = "http://www.zhzyw.org/";
            var pattern = "<div.*(?=webnr)(.|\n)*?</div>";
            var reg = new Regex(pattern, RegexOptions.IgnoreCase);
            Regex rega = new Regex("</?.+?>");//去掉标签
            //string strWebContent = GetWebContent(baseUrl + url, "gb2312");
            string strWebContent = GetWebContent(url, "gb2312");
            MatchCollection mc = reg.Matches(strWebContent);
            if (mc.Count > 0)
            {
                var strPageHtml = mc[0].Groups[0].Value;
                var webb = new WebBrowser();

                webb.Navigate("about:blank");

                var htmldoc = webb.Document.OpenNew(true);

                htmldoc.Write(strPageHtml);
                HtmlElementCollection htmldd = htmldoc.GetElementsByTagName("p");
                if (htmldd.Count != 0)
                {
                    for (int i = 0; i < htmldd.Count; i++)
                    {
                        var strong = htmldd[i].GetElementsByTagName("strong");

                        if (strong.Count > 0)
                        {
                            if (result != null && result.Count > 0)
                                list.Add(result);
                            result = new Dictionary<string, string>();
                            result.Add("名称", rega.Replace(strong[0].InnerText, ""));
                        }
                        else
                        {
                            var strV = htmldd[i].InnerText;
                            result.Add(strV.Substring(0, strV.IndexOf("】")).Replace("【", ""), rega.Replace(strV.Substring(strV.IndexOf("】") + 1), ""));
                        }
                        if (i == htmldd.Count - 1)
                        {
                            list.Add(result);
                        }
                    }
                }
                else
                {
                    var strHtml = htmldoc.GetElementsByTagName("div")[0].InnerHtml.Replace("<BR>", "");//.Replace("<BR><BR>", "&").Replace("</STRONG><BR>", "&");
                    var strS = strHtml.Split('【');
                    if (strHtml.Contains("<STRONG>"))
                    {
                        int i = 0;
                        foreach (var s in strS)
                        {
                            if (s.Contains("<STRONG>"))
                            {
                                if (result != null && result.Count > 0)
                                    list.Add(result);
                                result = new Dictionary<string, string>();
                                result.Add("名称", rega.Replace(s.Replace("<STRONG>", "").Replace("</STRONG>", ""), ""));
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(s))
                                    result.Add(s.Substring(0, s.IndexOf("】")).Replace("【", ""), rega.Replace(s.Substring(s.IndexOf("】") + 1), ""));
                            }
                            i++;
                            if (i == strS.ToList().Count)
                            {
                                list.Add(result);
                            }
                        }
                    }
                    else
                    {
                        result = new Dictionary<string, string>();
                        foreach (var s in strS)
                        {
                            if (!string.IsNullOrEmpty(s))
                                result.Add(s.Substring(0, s.IndexOf("】")).Replace("【", ""), rega.Replace(s.Substring(s.IndexOf("】") + 1), ""));
                        }
                        result.Add("名称", name);
                        list.Add(result);
                    }
                }
            }
            return list;
        }

        #endregion
    }
}
