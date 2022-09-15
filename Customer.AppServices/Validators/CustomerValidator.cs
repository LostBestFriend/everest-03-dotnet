using Customer.DomainModels.Models;
using FluentValidation;

namespace Customer.AppServices.Validations
{
    public class CustomerValidator : AbstractValidator<CustomersModel>
    {
        public CustomerValidator()
        {

            RuleFor(x => x.FullName).NotEmpty().WithMessage("Currency required");

            RuleFor(x => x.Email)
                .NotEmpty();

            RuleFor(x => x.EmailConfirmation)
                .NotEmpty()
                .EmailAddress()
                .Equal(x => x.Email).WithMessage("Email confirmation must be equal to Email");

            RuleFor(x => CpfValidator.IsCpfValid(x.Cpf))
                .NotEmpty()
                .WithMessage("CPF is invalid");

            RuleFor(x => x.Cellphone).NotEmpty().WithMessage("Currency required");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .GreaterThan(DateTime.MinValue)
                .WithMessage("Currency required");

            RuleFor(x => x.EmailSms).NotEmpty().WithMessage("Currency required");
            RuleFor(x => x.Whatsapp).NotEmpty().WithMessage("Currency required");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Currency required");
            RuleFor(x => x.City).NotEmpty().WithMessage("Currency required");
            RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Currency required");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Currency required");
            RuleFor(x => x.Number).NotEmpty().WithMessage("Currency required");
        }
    }
}

