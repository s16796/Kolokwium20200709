using Kolokwium20200709.DTO;
using Kolokwium20200709.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium20200709.Services
{
    public class ArtDbService : IArtDbService
    {

        public ArtDbContext _context;

        public ArtDbService(ArtDbContext context)
        {
            _context = context;
        }

        public bool AddArtist(AddNewArtistDtoRequest request)
        {
            _context.Database.BeginTransaction();
            var testcity = _context.Cities.Where(c => c.IdCity.Equals(request.IdCityOfBirth)).FirstOrDefault();
            if (testcity == null)
            {
                _context.Database.RollbackTransaction();
                throw new ArgumentException("Such City does not exist");
            }
            var testmovement = _context.Art_Movements.Where(m => m.IdArtMovement.Equals(request.IdArtMovement)).FirstOrDefault();
            if (testmovement == null)
            {
                _context.Database.RollbackTransaction();
                throw new ArgumentException("Such Movement does not exist");
            }
            var testexsist = _context.Artists.Where(a => a.Nickname.Equals(request.NickName)).FirstOrDefault();
            if(testexsist != null)
            {
                _context.Database.RollbackTransaction();
                throw new ArgumentException("Such Artist already exists");
            }

            var newArtist = new Artist
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Nickname = request.NickName,
                IdCityOfBirth = request.IdCityOfBirth,
                IdArtMovement = request.IdArtMovement,
                DateOfBirth = request.DateOfBirth
            };

            _context.Add(newArtist);
            _context.SaveChanges();
            _context.Database.CommitTransaction();
            return true;
        }

        public GetArtistInfoByIdDtoResponse GetArtistById(int id)
        {
            var artist = _context.Artists.Where(ar => ar.IdArtist.Equals(id)).FirstOrDefault();
            if (artist == null)
            {
                throw new ArgumentException("Artist with that id does not exist");
            }

            var response = new GetArtistInfoByIdDtoResponse();

            response.Artist = artist;
            response.Movement = new MovementResponse
            {
                Name = artist.Art_Movement.Name,
                DateFounded = artist.Art_Movement.DateFounded
            };
            var templist = new List<PaintingResponse>();

            foreach(var item in artist.PaintingsCoCreated)
            {
                templist.Add(new PaintingResponse
                {
                    SurfaceType = item.SurfaceType,
                    PaintingMedia = item.PaintingMedia,
                    CreatedAt = item.CreatedAt,
                    ArtistRole = "Co-Creator"
                });
            }
            foreach (var item in artist.PaintingsCreated)
            {
                templist.Add(new PaintingResponse
                {
                    SurfaceType = item.SurfaceType,
                    PaintingMedia = item.PaintingMedia,
                    CreatedAt = item.CreatedAt,
                    ArtistRole = "Creator"
                });
            }

            response.Paintings = templist.OrderByDescending(pares => pares.CreatedAt).ToList();

            return response;
        }
    }
}
