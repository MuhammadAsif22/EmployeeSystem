using FluentValidation;
using Employees.System.Models;

namespace Employees.System.Validators;

public class CreateUserDataValidator : AbstractValidator<EmployeeRequest>
{
    public CreateUserDataValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(100)
            .WithMessage("Name is too long");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is invalid");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("PhoneNumber is required")
            .MaximumLength(20);
    }
}