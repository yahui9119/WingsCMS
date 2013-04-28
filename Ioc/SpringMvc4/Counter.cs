using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc4
{
    public class Counter
    {
        private int _count;
        public int Count
        {
            get { return _count++; }
            set { _count = value; }
        }
    }
}