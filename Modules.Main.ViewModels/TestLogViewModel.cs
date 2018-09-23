using Common.Base.ViewModels;
using FluentValidation;

namespace Modules.Main.ViewModels
{
    public class TestLogViewModel : BaseViewModel
    {
        public string TestMessage { get; set; }
    }

    public class TestLogValidator : AbstractValidator<TestLogViewModel>
    {
        public TestLogValidator()
        {
            RuleFor(tl => tl.TestMessage)
                .NotEmpty()
                .WithMessage("Test Message cannot be empty.");

            RuleFor(tl => tl.TestMessage)
                .Length(4, 50)
                .WithMessage("Test Message required between 4 to 50 letters.");
        }
    }
}
