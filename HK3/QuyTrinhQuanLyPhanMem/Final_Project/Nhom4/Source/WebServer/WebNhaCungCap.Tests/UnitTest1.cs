using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebNhaCungCap.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoginCompanySuccess()
        {


            Assert.AreEqual(LoginCompany("new", "123456"), JsonConvert.SerializeObject(new { CompanyName = "new", Token = "123456789" }));
        }

        static string LoginCompany(string username, string password)
        {
            using (var c = new HttpClient())
            {
                c.DefaultRequestHeaders.Accept.Clear();
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string url = string.Format("http://localhost:10851/api/web/tokencompany/{0}/{1}", username, password);

                return c.GetStringAsync(url).Result;

            }
        }


        [TestMethod]
        public void LoginCompanyFail()
        {
            Assert.AreNotEqual(LoginCompany("new", "1234567"), JsonConvert.SerializeObject(new { CompanyName = "new", Token = "123456789" }));
        }
    }
}
