using FluentValidation;

namespace Application.Artists.Commands.DeleteArtist
{
    public class DeleteArtistCommandValidator : AbstractValidator<DeleteArtistCommand>
    {
        public DeleteArtistCommandValidator()
        {
            
        }
    }
}