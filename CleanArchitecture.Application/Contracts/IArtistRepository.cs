using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Contracts
{
    public interface IArtistRepository
    {
        Task<Artist> CreateArtistAsync(Artist artist);
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task<Artist> GetArtistByIdAsync(int id);
    }
}
