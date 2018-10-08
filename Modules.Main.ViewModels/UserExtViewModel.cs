using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Modules.Main.ViewModels
{
    public class UserExtViewModel : UserViewModel
    {
        public string Password { get; set; }
    }

    public class UserExtValidator : AbstractValidator<UserExtViewModel>
    {
        public UserExtValidator()
        {
            RuleFor(u => u.Username)
                .NotEmpty()
                .Length(6, 20)
                .WithMessage("Username should be between 6 and 20 characters.");
            RuleFor(u => u.Username)
                .Matches(@"^[a-zA-Z0-9_.-]+$")
                .WithMessage("Username only allows alphanumeric characters, '.' and '-'");

            RuleFor(u => u.FirstName)
                .NotEmpty()
                .Length(1, 100)
                .WithMessage("Firstname cannot be empty.");

            RuleFor(u => u.LastName)
                .NotEmpty()
                .Length(1, 100)
                .WithMessage("LastName cannot be empty.");

            RuleFor(u => u.Mobile)
                .NotEmpty()
                .Length(8, 20)
                .WithMessage("Mobile should be between 8 and 20 characters.");

            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Invalid email address");

            RuleFor(u => u.Gender)
                .NotEmpty()
                .Must(gender => gender == "Male" || gender == "Female")
                .WithMessage("Gender should be either 'Male' or 'Female'");

            RuleFor(u => u.UserRole)
                .NotEmpty()
                .WithMessage("UserRole cannot be empty.");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty.");
        }
    }
}
