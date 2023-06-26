using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.API.DTOs
{
    public partial class AlbumDTO
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
    }
}
