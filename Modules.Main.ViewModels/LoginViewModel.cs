using FluentValidation;

namespace Modules.Main.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(lvm => lvm.Username)
                .NotEmpty()
                .Length(6, 20)
                .Matches(@"^[a-zA-Z0-9_.-]+$");

            RuleFor(lvm => lvm.Password)
                .NotEmpty();
        }
    }
}
