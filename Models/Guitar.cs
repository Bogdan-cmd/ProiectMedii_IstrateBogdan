using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMediiMaster_BogdanIstrate.Models
{
    public class Guitar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }

        public AppCustomer AppCustomer { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<GuitarOrder> GuitarOrders { get; set; }
        public ICollection<ReleasedGuitar> ReleasedGuitar { get; set; }
    }
}
