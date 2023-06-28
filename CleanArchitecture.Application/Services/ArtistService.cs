using CleanArchitecture.Application.Contracts;
using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly ILogger<ArtistService> _logger;
        public ArtistService(IArtistRepository artistRepository, ILogger<ArtistService> logger)
        {
            _artistRepository = artistRepository;
            _logger = logger;
        }
        public async Task<Artist> CreateArtistAsync(Artist artist)
        {
            return await _artistRepository.CreateArtistAsync(artist);
        }
        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await _artistRepository.GetAllArtistsAsync();
        }

        public async Task<Artist> GetArtistByIdAsync(int id)
        {
            return await _artistRepository.GetArtistByIdAsync(id);
        }
    }
}
