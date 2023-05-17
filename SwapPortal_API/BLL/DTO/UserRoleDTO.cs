using System.ComponentModel.DataAnnotations;

namespace SwapPortal_API.BLL.DTO
{
    public class UserRoleDTO
    {
        [Key]
        public int UserRoleId { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserRolesName { get; set; }
    }
}
