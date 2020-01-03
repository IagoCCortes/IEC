using FluentValidation;

namespace Application.Artists.Queries.GetArtistDetail
{
    public class GetArtistDetailQueryValidator : AbstractValidator<GetArtistDetailQuery>
    {
        public GetArtistDetailQueryValidator()
        {
            RuleFor(a => a.Id).GreaterThan(0).WithMessage("Provide a valid value for Id");
        }
    }
}