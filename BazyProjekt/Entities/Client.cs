using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyProjekt.Entities
{
    internal class Client
    {
        private Int32 id { get; set; }
        public Int32 Id { get { return id; } set { id = value; } }

        private String username;
        public String Username { get { return username; } set { username = value; } }
        private String password { get; set; }
        private Boolean active { get; set; }
        private Int32 session_id;
        public Int32 Session_id { get { return session_id; } set { session_id = value; } }

        private Boolean logged = false;
        public Boolean Logged { get { return logged; } set { logged = value; } }


    }
}
