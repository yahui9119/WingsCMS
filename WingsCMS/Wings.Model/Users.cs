using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Model
{
    public class Users
    {
        public virtual string LogonId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual DateTime LastLogon { get; set; }
    }
}
