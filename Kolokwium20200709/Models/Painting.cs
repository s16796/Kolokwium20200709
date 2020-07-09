using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium20200709.Models
{
    public class Painting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPainting { get; set; }
        [MaxLength(100)]
        public String SurfaceType { get; set; }
        [MaxLength(100)]
        public String PaintingMedia { get; set; }
        [ForeignKey("Artist")]
        public int IdArtist { get; set; }
        [ForeignKey("CoArtist")]
        public int? IdCoArtist { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Artist CoArtist { get; set; }



    }
}
