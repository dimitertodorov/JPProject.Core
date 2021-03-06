﻿using JPProject.Sso.Domain.Validations.User;
using System;

namespace JPProject.Sso.Domain.Commands.User
{
    public class RegisterNewUserCommand : UserCommand
    {

        public RegisterNewUserCommand(string username, string email, string name, string phoneNumber, string password, string confirmPassword, DateTime birthdate, string socialNumber)
        {
            Birthdate = birthdate;
            SocialNumber = socialNumber;
            Username = username;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Password = password;
            ConfirmPassword = confirmPassword;

        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewUserCommandValidation(this).Validate(this);
            return ValidationResult.IsValid;
        }

        public Models.User ToModel()
        {
            return new Models.User(
                Email,
                Name,
                Username,
                PhoneNumber,
                Picture,
                SocialNumber,
                Birthdate
            );
        }
    }
}
