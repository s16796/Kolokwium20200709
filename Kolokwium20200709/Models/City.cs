using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium20200709.Models
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCity { get; set; }
        [MaxLength(100)]
        public String Name { get; set; }
        public int? Population { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
    }
}
