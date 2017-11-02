using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNhaCungCap.Utils
{
    public class CurrentMillis
    {
        private static readonly DateTime Jan1St1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        /// <summary>Get extra long current timestamp</summary>
        public static long CurrentTimeMillis { get { return (long)((DateTime.UtcNow - Jan1St1970).TotalMilliseconds); } }


        public static long DateTimeToLong(DateTime d)
        {
            return (long)(d - Jan1St1970).TotalMilliseconds;
        }
    }
}