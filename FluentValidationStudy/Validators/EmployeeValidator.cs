using FluentValidation;
using FluentValidationStudy.Models;

namespace FluentValidationStudy.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.Name).NotNull().WithMessage("Name is not null").NotEmpty().WithMessage("Name is not empty");
            RuleFor(e => e.CreatedDate).GreaterThan(DateTime.Now).WithMessage("Created date greater datetime now");
            RuleFor(e => e.Email).EmailAddress().WithMessage("check your e-mail address");
            RuleFor(e => e.Age).InclusiveBetween(18, 60).WithMessage("must be within your age range");
            RuleFor(e => e.PhoneNumber).Length(0, 11);

        }
    }
}
