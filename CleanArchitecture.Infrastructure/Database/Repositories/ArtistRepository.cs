using CleanArchitecture.Application.Contracts;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CleanArchitecture.Infrastructure.Database.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ChinookContext _dbContext;
        private readonly ILogger<ArtistRepository> _logger;

        public ArtistRepository(ChinookContext dbContext, ILogger<ArtistRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Artist> CreateArtistAsync(Artist artist)
        {
            await _dbContext.Artist.AddAsync(artist);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"CreateArtistAsync - {JsonSerializer.Serialize(artist)}");

            return artist;
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await _dbContext.Artist
                .ToListAsync();
        }

        public async Task<Artist> GetArtistByIdAsync(int id)
        {
            return await _dbContext.Artist
                .Include(a => a.Album)
                .FirstOrDefaultAsync();
        }

        public async Task<Artist> UpdateArtistAsync(Artist artist)
        {
            _logger.LogInformation($"CreateArtistAsync - {JsonSerializer.Serialize(artist)}");

            _dbContext.Update(artist);
            await _dbContext.SaveChangesAsync();

            return artist;
        }
    }
}
