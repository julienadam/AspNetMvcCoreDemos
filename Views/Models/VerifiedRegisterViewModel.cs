using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Views.Models;

public class VerifiedRegisterViewModel : IValidatableObject
{
    [EmailAddress]
    [Required]
    [DataType(DataType.EmailAddress)]
    [DisplayName("Email address")]
    [Remote("VerifyEmailIsUnique", "Register", ErrorMessage = "Email is already used")]
    public string Email { get; set; }

    [DisplayName("Date of birth")]
    [Required]
    [DataType(DataType.Date)]
    public DateTime? Birthday { get; set; }

    [Required]
    [Compare(nameof(PasswordVerification))]
    [PasswordValidation]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DisplayName("Verify your password")]
    [DataType(DataType.Password)]
    public string PasswordVerification { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var age = DateTime.Now - Birthday;
        if (Email.EndsWith(".fr") && (age?.TotalDays < 13 * 365))
        {
            yield return new ValidationResult(
                "Minors under 13 cannot register is this country", 
                new[] {nameof(Birthday)});
        }
    }
}