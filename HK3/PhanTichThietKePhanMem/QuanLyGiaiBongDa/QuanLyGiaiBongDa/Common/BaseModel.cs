/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 13/03/2017 - BaseModel
 */
using Microsoft.TeamFoundation.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiBongDa.Common
{

    public class BaseModel : ViewModelBase, IDataErrorInfo
    {
        #region IDataErrorInfo Members

        public string Error
        {
            get
            {
                //var v = ValidationFactory.CreateValidator(this.GetType());
                //var results = v.Validate(this);
                //return string.Join(" ",
                //    results.Select(r => r.Message).ToArray());
                //
                return string.Empty;
            }
        }
        public string this[string columnName]
        {
            get
            {
                //ValidationResults results = Validation.Validate(this);
                //foreach (ValidationResult result in results)
                //{
                //    if (result.Key == columnName)
                //    {
                //        return result.Message;
                //    }
                //}
                return string.Empty;
            }
        }

        public int ErrorCount
        {
            get
            {
                //var v = ValidationFactory.CreateValidator(this.GetType());
                //var results = v.Validate(this);
                //return results.Count;

                //
                return 0;
            }
        }

        #endregion

        /// <summary>
        /// Map fields in IDataReader object to current object's properties
        /// </summary>
        /// <param name="reader"></param>
        /// <remarks></remarks>
        public virtual void DataMap(IDataReader reader)
        {

        }

        public bool ColumnExists(IDataReader reader, string columnName)
        {
            for (int i = 0; i <= reader.FieldCount - 1; i++)
            {
                if ((reader.GetName(i) == columnName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
