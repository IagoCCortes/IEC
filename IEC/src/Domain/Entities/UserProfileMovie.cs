namespace Domain.Entities
{
    public class UserProfileMovie
    {
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string Review { get; set; }
        public int? Rating { get; set; }
        public bool Favorited { get; set; }
        public UserProfileMovieStatus UserProfileMovieStatus { get; set; }
        public int UserProfileMovieStatusId { get; set; }
    }
}