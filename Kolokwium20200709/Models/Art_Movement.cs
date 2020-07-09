using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium20200709.Models
{
    public class Art_Movement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArtMovement { get; set; }
        [ForeignKey("NextMovement")]
        public int? IdNextMovement { get; set; }
        public int IdMovementFounder { get; set; }
        [MaxLength(100)]
        public String Name { get; set; }
        public DateTime DateFounded { get; set; }

        public virtual Artist Founder { get; set; }
        public virtual Art_Movement NextMovement { get; set; }
        public ICollection<Art_Movement> PredecesorMovements { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
