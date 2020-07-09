using Kolokwium20200709.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium20200709.Services
{
    public interface IArtDbService
    {
        GetArtistInfoByIdDtoResponse GetArtistById(int id);
        bool AddArtist(AddNewArtistDtoRequest request);
    }
}
