using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Views.Models;

public class ResetPasswordRequestViewModel
{
    [DataType(DataType.EmailAddress)]
    [DisplayName("Email address")]
    [Remote("VerifyEmailExists", "Register", ErrorMessage = "Email is already used")]
    public string Email { get; set; }
}