using DataAccessLayer.DTO;
using FluentValidation;

namespace TestTask.Validators
{
    public class PersonValidator : AbstractValidator<ShortPersonDto>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Full name shouldn't be empty");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Date of birth shouldn't be empty")
                .LessThan(DateTimeOffset.Now).WithMessage("Choose write date of birth");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Please, choose ypur gender")
                .Must(GenderValidator);
        }

        protected bool GenderValidator(string? gender)
        {
            return gender == "male" || gender == "female";
        }
    }
}
