using Customer.AppModels.Dtos;
using FluentValidation;

namespace Customer.AppServices.Validator
{
    public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerDtoValidator()
        {

            RuleFor(x => x.FullName).NotEmpty();

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();

            RuleFor(x => x.EmailConfirmation)
                .NotEmpty()
                .Equal(x => x.Email);

            RuleFor(x => CpfValidator.IsCpfValid(x.Cpf))
                .NotEmpty()
                .WithMessage("CPF is invalid");

            RuleFor(x => x.Cellphone).NotEmpty();

            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .GreaterThan(DateTime.MinValue);
                
            RuleFor(x => x.EmailSms).NotEmpty();
            RuleFor(x => x.Whatsapp).NotEmpty();
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.PostalCode).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Number).NotEmpty();
        }
    }
}

