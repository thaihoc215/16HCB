/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 13/03/2017 - DiContainer
 */
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace QuanLyGiaiBongDa.Common
{
    public static class DiContainer
    {
        const string SectionName = "unity";

        static UnityConfigurationSection Section
        {
            //add reference System.Configuration
            get { return (UnityConfigurationSection)ConfigurationManager.GetSection(SectionName); }
        }

        public static T Inject<T>(T existing)
        {
            using (var container = new UnityContainer())
            {
                return Section.Configure(container).BuildUp<T>(existing);
            }
        }
    }
}
