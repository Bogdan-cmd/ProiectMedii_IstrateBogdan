using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectMediiMaster_BogdanIstrate.Models
{
    public class Factory
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Factory Name")]
        [StringLength(50)]
        public string FactoryName { get; set; }

        [StringLength(70)]
        public string Adress { get; set; }

        public ICollection<ReleasedGuitar> ReleasedGuitars { get; set; }
    }
}
