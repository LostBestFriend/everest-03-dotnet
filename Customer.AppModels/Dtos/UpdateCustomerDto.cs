﻿namespace Customer.AppModels.Dtos
{
    public class UpdateCustomerDto
    {
        public UpdateCustomerDto(
            string fullName,
            string email,
            string emailConfirmation,
            string cpf,
            string cellphone,
            DateTime dateOfBirth,
            string country,
            string city,
            string postalCode,
            string address,
            bool emailSms,
            bool whatsapp,
            int number)
        {

            FullName = fullName;
            Email = email;
            EmailConfirmation = emailConfirmation;
            Cpf = cpf;
            Cellphone = cellphone;
            DateOfBirth = dateOfBirth;
            Country = country;
            City = city;
            PostalCode = postalCode;
            Address = address;
            EmailSms = emailSms;
            Whatsapp = whatsapp;
            Number = number;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string EmailConfirmation { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public bool EmailSms { get; set; }
        public bool Whatsapp { get; set; }
        public int Number { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

