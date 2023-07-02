using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistDAO _artistDao;
        private readonly ILogger<ArtistService> _logger;

        public ArtistService(IArtistDAO artistDao, ILogger<ArtistService> logger)
        {
            _artistDao = artistDao;
            _logger = logger;
        }
        public async Task<Artist> CreateArtistAsync(Artist artist)
        {
            return await _artistDao.CreateArtistAsync(artist);
        }
        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await _artistDao.GetAllArtistsAsync();
        }

        public async Task<Artist> GetArtistByIdAsync(int id)
        {
            return await _artistDao.GetArtistByIdAsync(id);
        }

        public async Task<Artist> UpdateArtistAsync(Artist artist)
        {
            return await _artistDao.UpdateArtistAsync(artist);
        }
    }
}
