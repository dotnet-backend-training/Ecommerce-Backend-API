using Ecommerce_Backend_Core.DTO_s;
using FluentValidation;

namespace Ecommerce_Backend_API.Validators.Auth
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestValidator() {
            RuleFor(registerRequest => registerRequest.Username)
            .NotEmpty().WithMessage("Username is required")
            .MinimumLength(3).WithMessage("Username must be at least 3 characters.")
            .MaximumLength(20).WithMessage("Username must not exceed 20 characters.");

            RuleFor(registerRequest => registerRequest.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
            .MaximumLength(100).WithMessage("Password must not exceed 100 characters.")
            .Must(HaveAtLeastTwoUppercaseLetters).WithMessage("Password must contain at least two uppercase letters.")
            .Must(HaveAtLeastTwoLowercaseLetters).WithMessage("Password must contain at least two lowercase letters.")
            .Must(HaveAtLeastTwoDigits).WithMessage("Password must contain at least 2 digits.")
            .Must(HaveAtLeastOneSpecialChar).WithMessage("Password must contain at least one special character.");

            RuleFor(registerRequest => registerRequest.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Must be a valid email address");

            RuleFor(registerRequest => registerRequest.GovermentCode)
            .GreaterThan(0).WithMessage("GovermentCode is required and must be a positive number");

            RuleFor(registerRequest => registerRequest.CityCode)
            .GreaterThan(0).WithMessage("CityCode is required and must be a positive number");

            RuleFor(registerRequest => registerRequest.ZoneCode)
            .GreaterThan(0).WithMessage("ZoneCode is required and must be a positive number");

            RuleFor(registerRequest => registerRequest.CustomerClassificationId)
            .GreaterThan(0).WithMessage("CustomerClassificationId is required and must be a positive number");

        }
        private bool HaveAtLeastTwoUppercaseLetters(string password)
        {
            return password.Count(char.IsUpper) >= 2;
        }
        private bool HaveAtLeastTwoLowercaseLetters(string password)
        {
            return password.Count(char.IsLower) >= 2;
        }
        private bool HaveAtLeastTwoDigits(string password)
        {
           return password.Count(char.IsDigit) >= 2;
        }

        private bool HaveAtLeastOneSpecialChar(string password)
        {
            return password.Count(c => !char.IsLetterOrDigit(c)) >= 1;
        }
            
    }
}
