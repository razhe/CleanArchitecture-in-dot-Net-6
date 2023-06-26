using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Contracts
{
    public interface IArtistService
    {
        Task<Artist> CreateArtistAsync(Artist artist);
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task<Artist> GetArtistByIdAsync(int id);
    }
}
