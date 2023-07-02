using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CleanArchitecture.Infrastructure.Database.Abstractions
{
    public class ArtistDAO : IArtistDAO
    {
        private readonly ChinookContext _dbContext;
        private readonly ILogger<ArtistDAO> _logger;
        private ChinookContext db;

        public ArtistDAO(ChinookContext db)
        {
            this.db = db;
        }

        public ArtistDAO(ChinookContext dbContext, ILogger<ArtistDAO> logger)
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
    }
}
