using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace BaiTap1_Provider
{
    /// <summary>
    /// Summary description for PhapAnhService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PhapAnhService : System.Web.Services.WebService
    {
        private static Dictionary<string, string> _dictFrEn = new Dictionary<string, string>();
        [WebMethod]
        public void InitDictionary()
        {
            _dictFrEn = new Dictionary<string, string>();
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            FileStream fs = new FileStream(Server.MapPath("/") + @"FrenchEnglishDict.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("word");
            for (int i = 0; i <= xmlnode.Count - 1; i++)
            {
                string strFr = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                string strEn = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                _dictFrEn.Add(strFr, strEn);
            }
        }

        [WebMethod]
        public string Translate(string frenchMean)
        {
            string engMean = string.Empty;
            try
            {
                engMean = _dictFrEn[frenchMean];
            }
            catch (Exception)
            {
            }

            return engMean;
        }
    }
}
