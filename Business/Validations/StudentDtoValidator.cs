using Core.Dtos;
using FluentValidation;

namespace Business.Validations
{
    public class StudentDtoValidator : AbstractValidator<StudentDto>
    {
        public StudentDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required")
            .NotEmpty().WithMessage("{PropertyName} is not empty");

            RuleFor(x => x.Age).InclusiveBetween(7, int.MaxValue).WithMessage("{PropertyName} is must be greater than 7");
            RuleFor(x => x.DepartmentId).NotNull().InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} is must be greater than 0");
            RuleFor(x => x.CourseIds.Count).NotNull().InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} is must be greater than 0");

        }
    }
}
