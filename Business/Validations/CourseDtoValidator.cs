using Core.Dtos;
using FluentValidation;

namespace Business.Validations
{
    public class CourseDtoValidator : AbstractValidator<CourseDto>
    {
        public CourseDtoValidator()
        {
            RuleFor(x => x.CourseName)
                .NotNull().WithMessage("{PropertyName} is required")
                .MinimumLength(3).WithMessage("{PropertyName} must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("{PropertyName} must be at most 50 characters long.")
                .NotEmpty().WithMessage("{PropertyName} is not empty");
        }
    }
}
