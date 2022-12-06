using Microsoft.AspNetCore.Identity;

namespace SecurityDemo.Models
{
    public class AgeUser : IdentityUser
    {
        [ProtectedPersonalData]
        public DateTime DateOfBirth { get; set; }
    }
}
