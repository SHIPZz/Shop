using FluentValidation;
using Shop.Commands;

namespace Shop.Validators;

public class AddDeviceModelCommandValidator : AbstractValidator<AddOrderedDeviceModelCommand>
{
    public AddDeviceModelCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
        RuleFor(x => x.Count).GreaterThan(0).WithMessage("Count must be greater than zero.");
    }
}