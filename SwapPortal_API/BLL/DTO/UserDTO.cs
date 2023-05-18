using System.ComponentModel.DataAnnotations;

namespace SwapPortal_API.BLL.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username must be between 1 and 50 characters.", MinimumLength = 1)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]


        public string Password { get; set; }


        public string FName { get; set; }


        public string LName { get; set; }



        public UserRoleDTO UserRole { get; set; }
    }
}
