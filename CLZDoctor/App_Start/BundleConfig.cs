using System.Web;
using System.Web.Optimization;

namespace CLZDoctor
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            //绑定bootstrap.js
            bundles.Add(new ScriptBundle("~/Scripts/bootstrapjs").Include("~/Scripts/bootstrap.js"));

            //绑定bootstrap.css
            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-theme.css"));
            //绑定easyui
            bundles.Add(new ScriptBundle("~/bundles/easyui/js").Include(
                        "~/Scripts/jquery-easyui-1.4/jquery.easyui.js",
                        "~/Scripts/jquery-easyui-1.4/locale/easyui-lang-zh_CN.js"));
            bundles.Add(new StyleBundle("~/Content/themes/bootstrap/css").Include(
                        "~/Content/themes/bootstrap/easyui.css",
                        "~/Content/themes/icon.css",
                        "~/Content/themes/color.css"));

        }
    }
}