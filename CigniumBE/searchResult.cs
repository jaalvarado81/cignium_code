using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CigniumBE
{
    public class searchResult : ICloneable
    {
        public string search { get; set; }
        public string engine { get; set; }
        public double resultsCount { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}