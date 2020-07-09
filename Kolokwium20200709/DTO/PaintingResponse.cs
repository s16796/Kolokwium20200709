using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium20200709.DTO
{
    public class PaintingResponse
    {
        public String SurfaceType { get; set; }
        public String PaintingMedia { get; set; }
        public DateTime CreatedAt { get; set; }
        public String ArtistRole { get; set; }
    }
}
