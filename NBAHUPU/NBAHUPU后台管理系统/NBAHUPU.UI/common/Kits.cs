using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBAHUPU.UI
{
    public class Kits
    {
        public static bool IsNumber(string s)
        {
            int num;
            return int.TryParse(s, out num);
        }
    }
}