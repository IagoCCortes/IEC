namespace Domain.Entities
{
    public class UserMovie
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string Review { get; set; }
        public int? rating { get; set; }
        public bool Favorited { get; set; }
        public UserMovieStatus UserMovieStatus { get; set; }
        public int UserMovieStatusId { get; set; }
    }
}