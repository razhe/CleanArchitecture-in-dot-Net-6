namespace CleanArchitecture.API.DTOs
{
    public partial class ArtistAlbumDTO
    {
        public int? ArtistId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AlbumDTO> Album { get; set; }
    }
}
