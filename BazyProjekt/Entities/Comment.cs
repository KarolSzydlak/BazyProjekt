using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyProjekt.Entities
{
    internal class Comment
    {
        private Int32 id_comment { get; set; }
        public Int32 Id_comment { get { return id_comment; } set { id_comment = value; } }

        private Int32 id_event { get; set; }
        public Int32 Id_event { get { return id_event; } set { id_event = value; } }

        private String content { get; set; }
        public String Content { get { return content; } set { content = value; } }

        private Int32 id_user { get; set; }
        public Int32 Id_user { get { return id_user; } set { id_user = value; } }
    }
}
