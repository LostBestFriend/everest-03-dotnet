using FluentValidation;

namespace _01_Back_End_Criação_de_Usuário
{
    public class CustomersValidator : AbstractValidator<CustomersModel>
    {

        public CustomersValidator()
        {

            RuleFor(x => x.FullName).NotNull().WithMessage("Currency required");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("Email already exists");

            RuleFor(x => x.EmailConfirmation)
                .NotNull()
                .EmailAddress()
                .Equal(x => x.Email).WithMessage("Email confirmation must be equal to Email");

            RuleFor(x => CPFValidation.IsCPFValid(x.Cpf))
                .Equal(true)       
                .WithMessage("CPF is invalid");

            RuleFor(x => x.Cellphone).NotNull().WithMessage("Currency required");

            RuleFor(x => x.DateOfBirth)
                .NotNull()
                .GreaterThan(DateTime.MinValue)
                .WithMessage("Currency required");

            RuleFor(x => x.EmailSms).NotNull().WithMessage("Currency required");
            RuleFor(x => x.Whatsapp).NotNull().WithMessage("Currency required");
            RuleFor(x => x.Country).NotNull().WithMessage("Currency required");
            RuleFor(x => x.City).NotNull().WithMessage("Currency required");
            RuleFor(x => x.PostalCode).NotNull().WithMessage("Currency required");
            RuleFor(x => x.Address).NotNull().WithMessage("Currency required");
            RuleFor(x => x.Number).NotNull().WithMessage("Currency required");

        }



    }
}
