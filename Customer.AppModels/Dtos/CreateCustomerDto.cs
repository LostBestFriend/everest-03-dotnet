namespace Customer.AppModels.Dtos
{
    public class CreateCustomerDto
    {
        public CreateCustomerDto(
            string fullName,
            string email,
            string emailConfirmation,
            string cpf,
            string cellphone,
            DateTime dateOfBirth,
            bool emailSms,
            bool whatsapp,
            string country,
            string city,
            string postalCode,
            string address,
            int number)
        {
            FullName = fullName;
            Email = email;
            EmailConfirmation = emailConfirmation;
            EmailSms = emailSms;
            Cellphone = cellphone;
            DateOfBirth = dateOfBirth;
            Cpf = cpf;
            Whatsapp = whatsapp;
            Country = country;
            City = city;
            PostalCode = postalCode;
            Address = address;
            Number = number;  
        }

        protected CreateCustomerDto() { }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string EmailConfirmation { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public bool EmailSms { get; set; }
        public bool Whatsapp { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

