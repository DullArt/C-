using System.Web;
using System.Web.Optimization;

namespace LojaRazor
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            StyleBundle estilos = new StyleBundle("~/bundles/estilos");
            estilos.Include("~/Content/Style.css");
            estilos.Include("~/Content/bootstrap/css/bootstrap.css");
            bundles.Add(estilos);

            ScriptBundle scripts = new ScriptBundle("~/bundles/scripts");
            scripts.Include("~/Content/Scripts/jquery-1.7.1.js");
            scripts.Include("~/Content/Scripts/jquery.validate.js");
            bundles.Add(scripts);    

        }
    }
}