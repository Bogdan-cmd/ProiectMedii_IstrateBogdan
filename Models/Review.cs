using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMediiMaster_BogdanIstrate.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int GuitarId { get; set; }
        public int AppCustomerId { get; set; }
        public int Rating { get; set; }
        public AppCustomer AppCustomer { get; set; }
        public Guitar Guitar { get; set; }
        public ICollection<GuitarOrder> GuitarOrders { get; set; }
    }
}
