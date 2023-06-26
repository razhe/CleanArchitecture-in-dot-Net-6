using CleanArchitecture.Application.Contracts;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Database.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ChinookContext _dbContext;

        public ArtistRepository(ChinookContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Artist> CreateArtistAsync(Artist artist)
        {
            await _dbContext.Artist.AddAsync(artist);
            await _dbContext.SaveChangesAsync();
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
