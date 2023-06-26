using AutoMapper;
using CleanArchitecture.API.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.API.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Album, AlbumDTO>()
                .ReverseMap();
            this.CreateMap<Artist, ArtistDTO>()
                .ReverseMap();
            this.CreateMap<Artist, ArtistAlbumDTO>()
                .ReverseMap();
        }
    }
}
