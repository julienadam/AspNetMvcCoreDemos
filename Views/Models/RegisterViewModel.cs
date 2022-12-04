using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Views.Models
{
    public class RegisterViewModel
    {
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email address")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
