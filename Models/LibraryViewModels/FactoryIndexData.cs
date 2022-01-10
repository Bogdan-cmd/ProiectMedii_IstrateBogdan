using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMediiMaster_BogdanIstrate.Models.LibraryViewModels
{
    public class FactoryIndexData
    {
        public IEnumerable<Factory> Factories { get; set; }
        public IEnumerable<Guitar> Guitars { get; set; }
        public IEnumerable<GuitarOrder> GuitarOrders { get; set; }
    }
}
