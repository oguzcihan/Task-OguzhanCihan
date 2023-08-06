using Core.Dtos;
using FluentValidation;

namespace Business.Validations
{
    public class RegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Username)
               .NotNull().WithMessage("{PropertyName} is required")
               .MinimumLength(3).WithMessage("{PropertyName} must be at least 3 characters long.")
               .MaximumLength(50).WithMessage("{PropertyName} must be at most 50 characters long.")
               .NotEmpty().WithMessage("{PropertyName} is not empty");

            RuleFor(x => x.Firstname)
               .NotNull().WithMessage("{PropertyName} is required")
               .MinimumLength(3).WithMessage("{PropertyName} must be at least 3 characters long.")
               .MaximumLength(50).WithMessage("{PropertyName} must be at most 50 characters long.")
               .NotEmpty().WithMessage("{PropertyName} is not empty");

            RuleFor(x => x.Password)
               .NotNull().WithMessage("{PropertyName} is required")
               .MinimumLength(3).WithMessage("{PropertyName} must be at least 3 characters long.")
               .MaximumLength(50).WithMessage("{PropertyName} must be at most 50 characters long.")
               .NotEmpty().WithMessage("{PropertyName} is not empty");

            RuleFor(x => x.Email)
               .NotNull().WithMessage("{PropertyName} is required")
               .MinimumLength(3).WithMessage("{PropertyName} must be at least 3 characters long.")
               .MaximumLength(50).WithMessage("{PropertyName} must be at most 50 characters long.")
               .NotEmpty().WithMessage("{PropertyName} is not empty");
        }
    }
}
