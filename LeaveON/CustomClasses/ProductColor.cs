using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MYBUSINESS.CustomClasses
{
    public class ProductColor
    {
        public static string AssignColor(decimal? Stock)
        {
            string RackPosition="";
            
            if (Stock >= 5)
            { RackPosition = "Green"; }
            
            if (Stock < 5 && Stock > 0)
            { RackPosition = "Yellow"; }
            
            if (Stock <= 0)
            { RackPosition = "Red"; }
            return RackPosition;
        }
    }
}