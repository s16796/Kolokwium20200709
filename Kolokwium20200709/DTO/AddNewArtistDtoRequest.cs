using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium20200709.DTO
{
    public class AddNewArtistDtoRequest
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String NickName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int IdArtMovement { get; set; }
        public int? IdCityOfBirth { get; set; }
    }
}
