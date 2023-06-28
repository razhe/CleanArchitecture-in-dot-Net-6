using AutoMapper;
using CleanArchitecture.API.DTOs;
using CleanArchitecture.Application.Contracts;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;
        public ArtistsController(IArtistService artistService, IMapper mapper)
        {
            _artistService = artistService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<ArtistDTO>>> GetArtists()
        {
            var result = await _artistService.GetAllArtistsAsync();
            var artistList = _mapper.Map<IEnumerable<ArtistDTO>>(result);

            return Ok(artistList);
        }
        [HttpGet]
        [Route("artist/{id}")]
        public async Task<ActionResult<ArtistAlbumDTO>> GetArtistById([FromRoute] int id)
        {
            var result = await _artistService.GetArtistByIdAsync(id);
            var artist = _mapper.Map<ArtistAlbumDTO>(result);
            
            return Ok(artist);
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ArtistDTO>> PostCreateArtistAsync([FromBody] ArtistDTO artist)
        {
            var newArtist = _mapper.Map<Artist>(artist);
            var results = await _artistService.CreateArtistAsync(newArtist);
            return Ok(results);
        }
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<ArtistDTO>> PutUpdateArtistAsync([FromBody] ArtistDTO artist)
        {
            var updatedArtist = _mapper.Map<Artist>(artist);
            var results = await _artistService.UpdateArtistAsync(updatedArtist);
            return Ok(results);
        }
    }
}
