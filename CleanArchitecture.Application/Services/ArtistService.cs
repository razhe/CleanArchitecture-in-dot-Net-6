using AutoMapper;
using CleanArchitecture.Application.Contracts;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }
        public async Task<Artist> CreateArtistAsync(Artist artist)
        {
            return await _artistRepository.CreateArtistAsync(artist);
        }
        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await _artistRepository.GetAllArtistsAsync();
        }
    }
}
