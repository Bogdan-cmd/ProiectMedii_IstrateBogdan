using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMediiMaster_BogdanIstrate.Models
{
    public class AppCustomer 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AppCustomerId { get; set; }
        public string Name { get; set; }
        public ICollection<Guitar> Guitars { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<GuitarOrder> GuitarOrders { get; set; }

    }
}
