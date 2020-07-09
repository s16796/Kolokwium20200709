using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium20200709.Models
{
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArtist { get; set; }
        [ForeignKey("Art_Movement")]
        public int IdArtMovement { get; set; }
        [ForeignKey("CityOfBirth")]
        public int? IdCityOfBirth { get; set; }
        [MaxLength(100)]
        public String FirstName { get; set; }
        [MaxLength(100)]
        public String LastName { get; set; }
        [MaxLength(100)]
        public String? Nickname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual City CityOfBirth { get; set; }
        public virtual Art_Movement Art_Movement { get; set; }
        public virtual ICollection<Painting> PaintingsCreated { get; set; }
        public virtual ICollection<Painting> PaintingsCoCreated { get; set; }

    }
}
