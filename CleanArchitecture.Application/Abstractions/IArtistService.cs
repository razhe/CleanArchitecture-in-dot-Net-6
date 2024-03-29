﻿using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Abstractions
{
    public interface IArtistService
    {
        Task<Artist> CreateArtistAsync(Artist artist);
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task<Artist> GetArtistByIdAsync(int id);
        Task<Artist> UpdateArtistAsync(Artist artist);
    }
}
