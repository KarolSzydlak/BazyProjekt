using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyProjekt.Entities
{
    internal class Mastermind
    {
        private Int32 id_org { get; set; }
        public Int32 Id_org { get { return id_org; } set { id_org = value; } }
        private String name { get; set; }
        public String Name { get { return name; } set { name = value; } }
        private Int32 id_address { get; set; }
        public Int32 Id_address { get { return id_address; } set { id_address = value; } }
        private Int32 id_user { get; set; }
        public Int32 Id_user { get { return id_user; } set { id_user = value; } }

    }
}
