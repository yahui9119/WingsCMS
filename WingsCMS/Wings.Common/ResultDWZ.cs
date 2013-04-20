using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Common
{
    public class ResultDWZ
    {
        public string statusCode { get; set; }
        public string message { get; set; }
        public string navTabId {get;set;}
        public string rel { get; set; }
        public string callbackType { get; set; }
        public string forwardUrl { get; set; }

    }
}
