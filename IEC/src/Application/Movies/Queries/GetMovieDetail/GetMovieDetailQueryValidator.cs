using FluentValidation;

namespace Application.Movies.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailQueryValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
        }
    }
}