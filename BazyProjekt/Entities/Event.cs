using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyProjekt.Entities
{
    internal class Event
    {
        private Int32 id_event { get; set; }
        public Int32 Id_event { get { return id_event; } set { id_event = value; } }
        private String name { get; set; }
        public String Name { get { return name; } set { name = value; } }
        private Int32 id_address { get; set; }
        public Int32 Id_address { get { return id_address; } set { id_address = value; } }
        private DateTime date {get; set;}
        public DateTime Date { get { return date; } set { date = value; } }
        private TimeSpan timeSpan { get; set; }
        public TimeSpan TimeSpan { get { return timeSpan; }set { timeSpan = value; } }
        private Int32 category_id { get; set; }
        public Int32 Category_id { get { return category_id; } set { category_id = value; } }
        private Int32 id_org { get; set; }
        public Int32 Id_org { get { return id_org; } set { id_org = value; } }
        private String description { get; set; }
        public String Description { get { return description; } set { description = value; } }
    }
}
