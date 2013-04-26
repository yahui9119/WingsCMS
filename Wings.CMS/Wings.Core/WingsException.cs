using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Core
{
    [Serializable]
    public class WingsException:Exception
    {
        public WingsException(string message)
            : base(message)
        {
        }
    }
}
