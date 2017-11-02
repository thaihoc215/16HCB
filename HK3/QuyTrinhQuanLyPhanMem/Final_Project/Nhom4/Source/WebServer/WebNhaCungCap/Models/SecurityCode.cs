using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNhaCungCap.Models
{
    public class SecurityCode
    {
        private string code;
        private long  timeAlive;
        public SecurityCode(string code, long timeAlive)
        {
            this.code = code;
            this.timeAlive = timeAlive;
        }

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public long TimeAlive
        {
            get
            {
                return timeAlive;
            }

            set
            {
                timeAlive = value;
            }
        }
    }
}