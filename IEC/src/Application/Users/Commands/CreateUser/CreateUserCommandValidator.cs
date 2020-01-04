using FluentValidation;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("Required Field.").EmailAddress().WithMessage("The field must be a valid email address");
        }        
    }
}