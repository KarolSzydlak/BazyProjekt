using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyProjekt.Entities
{
    internal class Street
    {
        private Int32 id_city { get; set; }
        public Int32 Id_city { get { return id_city; } set { id_city = value; } }
        private String name { get; set; }
        public String Name { get { return name; } set { name = value; } }

    }
}
