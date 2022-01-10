using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMediiMaster_BogdanIstrate.Models
{
    public class GuitarOrder
    {
        public int GuitarOrderId { get; set; }
        public int AppCustomerId { get; set; }
        public int GuitarId { get; set; }
        public DateTime OrderDate { get; set; }


        public Guitar Guitar { get; set; }
        public AppCustomer AppCustomer { get; set; }
        public Review Review { get; set; }
    }
}
