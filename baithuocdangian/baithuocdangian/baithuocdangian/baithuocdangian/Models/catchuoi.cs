using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace baithuocdangian.Models
{
    public class catchuoi
    {
        public string layChuoi(string str, int sokytu)
        {
            string str2 = "";
            if (str.Length > sokytu)
            {
                str2 = str.Substring(0, sokytu);
                for (int i = sokytu; i < str.Length; i++)
                {
                    if (str[i].Equals(' '))
                    {
                        str2 = str2 + "...";
                        return str2;
                    }
                    else
                    {
                        str2 = str2 + str[i];
                    }
                }
            }
            else
            {
                str2 = str + "...";
            }
            return str2;
        }

    }
}