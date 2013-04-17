using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.Common;

namespace Wings.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DESEncrypt des = new DESEncrypt();
            string str = des.Encrypt("Server=KEVIN-PC;Integrated Security=SSPI;database=JustTest_DB;user=sa;pwd=123456", "");
        }
    }
}
