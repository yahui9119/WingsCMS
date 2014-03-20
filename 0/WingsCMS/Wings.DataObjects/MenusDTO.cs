using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.DataObjects
{

    [Serializable]
    public class MenusDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Url = "javascript:;";
        public string ICO { get; set; }
        public List<MenusDTO> ChildMenus { get; set; }
    }
}
