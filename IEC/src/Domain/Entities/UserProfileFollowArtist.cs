namespace Domain.Entities
{
    public class UserProfileFollowArtist
    {
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}