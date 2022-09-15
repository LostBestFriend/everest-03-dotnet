using Customer.AppModels.Dtos;
using FluentValidation;

namespace Customer.AppServices.Validator
{
    public class UpdateCustomerDtoValidator : AbstractValidator<UpdateCustomerDto>
    {
        public UpdateCustomerDtoValidator()
        {
            RuleFor(x => x.FullName).NotEmpty();

            RuleFor(x => x.Email)
                    .NotEmpty()
                    .EmailAddress();

            RuleFor(x => x.Cpf)
                    .NotEmpty()
                    .Must(cpf => CpfValidator.IsCpfValid(cpf)).WithMessage("CPF is invalid");

            RuleFor(x => x.Cellphone).NotEmpty();

            RuleFor(x => x.DateOfBirth)
                    .NotEmpty()
                    .GreaterThan(DateTime.MinValue);
                    
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.PostalCode).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Number).NotEmpty();
        }
    }
}
