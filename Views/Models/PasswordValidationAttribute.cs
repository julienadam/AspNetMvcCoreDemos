using System.ComponentModel.DataAnnotations;

namespace Views.Models
{
    public class PasswordValidationAttribute : ValidationAttribute
    {
        public bool MustHaveNumber { get; init; } = true;
        public bool MustHaveCapital { get; init; } = true;
        public bool MustHaveSpecial { get; init; } = true;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("No password set");
            }

            string password = (string)value;
            if (MustHaveNumber)
            {
                if (!password.Any(char.IsNumber))
                {
                    return new ValidationResult("Password must contain a number");
                }
            }
            if (MustHaveCapital)
            {
                if (!password.Any(char.IsUpper))
                {
                    return new ValidationResult("Password must contain an uppercase letter");
                }
            }
            if (MustHaveSpecial)
            {
                if (!password.Any(c => !char.IsNumber(c) && !char.IsLetter(c)))
                {
                    return new ValidationResult("Password must contain a special character");
                }
            }

            return ValidationResult.Success;
        }
    }
}
