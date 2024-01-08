using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyProjekt.Entities
{
    internal class Address
    {
        private Int32 id_address { get; set; }
        private Int32 id_city { get; set; }
        private Int32 id_street { get; set; }
        private Int16 apartment_nr { get; set; }
        private Int16 building_nr { get; set; }
    }
}
