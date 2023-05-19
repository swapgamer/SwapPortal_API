using System.ComponentModel.DataAnnotations;

namespace SwapPortal_API.BLL.DTO
{
    public class AddLoginRequestDTO
    {


        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, ErrorMessage = "Password must be between 6 and 50 characters.", MinimumLength = 6)]
        public string Password { get; set; }

    }
}
