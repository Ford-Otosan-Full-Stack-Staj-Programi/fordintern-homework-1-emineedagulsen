using FluentValidation;
using FordApi.Data;
namespace FordApi;
public class StaffValidator : AbstractValidator<Staff>
{
   public StaffValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("The email address is required!")
             .EmailAddress().WithMessage("Please enter valid email address!")
             .Must(x => x.Contains("@"))
                         .WithMessage("The email address must contain '@' symbol")
                         .Must(x => x.Contains(".")).WithMessage("The email address must contain '.' ");

        RuleFor(x => x.CreatedAt).NotEmpty().WithMessage("Please fill with date and time!");

        RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Please fill with date and time!");

        RuleFor(p => p.Phone)
        .NotEmpty()
        .NotNull().WithMessage("Phone Number is required.")
        .Must(x=>x.Contains("+")).WithMessage("+ is required")
        .Matches(@"^\+(?:[0-9] ?){6,14}[0-9]$").WithMessage("Please enter valid phone number!!");
        // + kodu ile başlar ardından 6 ile 14 rakam arasında bir sayı içerir.
    }
}