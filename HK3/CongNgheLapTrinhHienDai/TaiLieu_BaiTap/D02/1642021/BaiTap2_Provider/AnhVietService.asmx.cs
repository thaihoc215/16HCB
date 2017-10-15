using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace BaiTap2_Provider
{
    /// <summary>
    /// Summary description for AnhVietService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AnhVietService : System.Web.Services.WebService
    {

        private static Dictionary<string, string> _dictEnVi = new Dictionary<string, string>();
        [WebMethod]
        public void InitDictionary()
        {
            _dictEnVi = new Dictionary<string, string>();
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            FileStream fs = new FileStream(@"E:\STUDY\AllLearnWork\School\16HCB1\16HCB\HK3\CongNgheLapTrinhHienDai\TaiLieu_BaiTap\D02\1642021\BaiTap2_Provider\EnglishVietnameseDict.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("word");
            for (int i = 0; i <= xmlnode.Count - 1; i++)
            {
                string strEn = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                string strvi = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                
                _dictEnVi.Add(strEn, strvi);
            }
        }

        [WebMethod]
        public string Translate(string engMean)
        {
            string viMean = string.Empty;
            try
            {
                viMean = _dictEnVi[engMean];
            }
            catch (Exception)
            {
            }

            return viMean;
        }
    }
}
