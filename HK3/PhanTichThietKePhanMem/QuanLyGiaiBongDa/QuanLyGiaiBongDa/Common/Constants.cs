using QuanLyGiaiBongDa.Models;
using System;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace QuanLyGiaiBongDa.Common
{
    public static class Constants
    {
        public static string PATH_LOCAL = Directory.GetParent(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).Parent.FullName;
        public static string IMAGE_DOIBONGAVA_FOLDER = PATH_LOCAL + Path.DirectorySeparatorChar
            + "Resources" + Path.DirectorySeparatorChar + "Images" + Path.DirectorySeparatorChar + "DoibongAva";

        //Get link cua anh dai dien tu thu muc goc trong project
        public static string IMAGE_CAUTHUAVA_FOLDER = PATH_LOCAL + Path.DirectorySeparatorChar
            + "Resources" + Path.DirectorySeparatorChar + "Images" + Path.DirectorySeparatorChar + "CauthuAva";

        public static NguoiDungModel UserUsing = new NguoiDungModel();
        /// <summary>
        /// set uri and make an image bitmap source for image
        /// </summary>
        /// <param name="imageUrl">path file</param>
        /// <returns></returns>
        public static BitmapImage SetImageSource(string imageUrl)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imageUrl);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;//dispose connection file
            bitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bitmap.EndInit();
            return bitmap;
        }

        public static object GetBoundValue(object value)
        {
            if (value is BindingExpression)
            {
                // ValidationStep was UpdatedValue or CommittedValue (Validate after setting)
                // Need to pull the value out of the BindingExpression.
                BindingExpression binding = (BindingExpression)value;

                // Get the bound object and name of the property
                object dataItem = binding.DataItem;
                string propertyName = binding.ParentBinding.Path.Path;

                try
                {
                    // Extract the value of the property.
                    object propertyValue = dataItem.GetType().GetProperty(propertyName).GetValue(dataItem, null);

                    // This is what we want.
                    return propertyValue;
                }
                catch (Exception)
                {

                    return value;
                }
            }
            else
            {
                // ValidationStep was RawProposedValue or ConvertedProposedValue
                // The argument is already what we want!
                return value;
            }
        }
    }
}
