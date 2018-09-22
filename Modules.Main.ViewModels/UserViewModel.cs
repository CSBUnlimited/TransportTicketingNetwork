using Common.Base.ViewModels;
using FluentValidation;

namespace Modules.Main.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }

    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
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
        }
    }
}
