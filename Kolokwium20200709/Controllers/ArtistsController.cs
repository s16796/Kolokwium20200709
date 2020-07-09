using Kolokwium20200709.DTO;
using Kolokwium20200709.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium20200709.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtDbService _service;

        public ArtistsController(IArtDbService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetArsist(int id)
        {
            try
            {
                return Ok(_service.GetArtistById(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult AddArtist([FromBody]AddNewArtistDtoRequest request)
        {
            try
            {
                return Ok(_service.AddArtist(request));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
