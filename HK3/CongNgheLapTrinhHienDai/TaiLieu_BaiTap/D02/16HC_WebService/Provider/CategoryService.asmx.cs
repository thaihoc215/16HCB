using System.Collections.Generic;
using System.Linq;
using System.Web.Services;

namespace Provider
{
    /// <summary>
    /// Summary description for CategoryService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CategoryService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<CategoryModel> GetList()
        {
            using (var ctx = new qlbhEntities()) {
                var list = ctx.Categories
                    .Select(c => new CategoryModel { 
                        CatID = c.CatID, 
                        CatName = c.CatName 
                    }).ToList();

                return list;
            }
        }
    }
}
