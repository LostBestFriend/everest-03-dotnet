using Customer.AppModels.Dtos;
using FluentValidation;

namespace Customer.AppServices.Validator
{
    public class UpdateCustomerDtoValidator : AbstractValidator<UpdateCustomerDto>
    {
        public UpdateCustomerDtoValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Currency required");

            RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Currency Required")
                    .EmailAddress().WithMessage("Invalid Email");

            RuleFor(x => x.Cpf)
                    .NotEmpty().WithMessage("Currency required")
                    .Must(cpf => CpfValidator.IsCpfValid(cpf)).WithMessage("CPF is invalid");

            RuleFor(x => x.Cellphone).NotEmpty().WithMessage("Currency required");

            RuleFor(x => x.DateOfBirth)
                    .NotEmpty()
                    .GreaterThan(DateTime.MinValue)
                    .WithMessage("Currency required");

            RuleFor(x => x.Country).NotEmpty().WithMessage("Currency required");
            RuleFor(x => x.City).NotEmpty().WithMessage("Currency required");
            RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Currency required");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Currency required");
            RuleFor(x => x.Number).NotEmpty().WithMessage("Currency required");
        }
    }
}
