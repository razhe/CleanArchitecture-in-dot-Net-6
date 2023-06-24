using AutoMapper;
using CleanArchitecture.API.DTOs;
using CleanArchitecture.Application.Contracts;
using Microsoft.AspNetCore.Http;
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
        //[HttpPost]
        //[Route("/artist")]
        //public async Task<ActionResult<ArtistDTO>> PostCreateArtist()
        //{
            
        //}
    }
}
