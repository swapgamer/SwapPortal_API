using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwapPortal_API.BLL.DTO
{
    public class AddUserRequestDTO
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(60, ErrorMessage = "Password must be between 6 and 60 characters.", MinimumLength = 6)]
        public string Password { get; set; }


        public string FName { get; set; }


        public string LName { get; set; }

        [Required]
        [ForeignKey("UserRole")]
        public int UserRoleId { get; set; }
        //  public virtual UserRole UserRole { get; set; }

    }
}
