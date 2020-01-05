using FluentValidation;

namespace Application.UserProfiles.Commands.CreateUserProfile
{
    public class CreateUserProfileCommandValidator : AbstractValidator<CreateUserProfileCommand>
    {
        public CreateUserProfileCommandValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("Required Field.").EmailAddress().WithMessage("The field must be a valid email address");
        }        
    }
}