using Kolokwium20200709.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Kolokwium20200709.DTO
{
    public class GetArtistInfoByIdDtoResponse
    {
        public Artist Artist { get; set; }
        public List<PaintingResponse> Paintings { get; set; }
        public MovementResponse Movement { get; set; }
    }
}
