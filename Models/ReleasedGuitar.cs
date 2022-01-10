using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMediiMaster_BogdanIstrate.Models
{
    public class ReleasedGuitar
    {
        public int FactoryID { get; set; }
        public int GuitarID { get; set; }
        public Factory Factory { get; set; }
        public Guitar Guitar { get; set; }
    }
}
