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
        private Int32 id_event { get; set; }
        private String content { get; set; }
        private Int32 id_user { get; set; }
    }
}
