using AutoMapper;
using CleanArchitecture.API.DTOs;
using CleanArchitecture.Application.Abstractions;
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
    }
}
