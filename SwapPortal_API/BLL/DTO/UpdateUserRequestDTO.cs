using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwapPortal_API.BLL.DTO
{
    public class UpdateUserRequestDTO
    {
        public string UserName { get; set; }


        public string Email { get; set; }


        public string Password { get; set; }


        public string FName { get; set; }


        public string LName { get; set; }

        [Required]
        [ForeignKey("UserRole")]
        public int UserRoleId { get; set; }
    }
}
