using Infrastructure.CrossCutting;

namespace DomainModels
{
    public class Customer : IEntity
    {
        public Customer(
           string fullName,
           string email,
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
            EmailSms = emailSms;
            Cellphone = cellphone;
            DateOfBirth = dateOfBirth;
            Cpf = cpf.FormatCpf();
            Whatsapp = whatsapp;
            Country = country;
            City = city;
            PostalCode = postalCode;
            Address = address;
            Number = number;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
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
        public long Id { get; set; }
    }
}
