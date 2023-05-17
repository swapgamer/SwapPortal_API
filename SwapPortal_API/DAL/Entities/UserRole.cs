using System.ComponentModel.DataAnnotations;

namespace SwapPortal_API.DAL.Entities
{
    public class UserRole
    {

        [Key]
        public int UserRoleId { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserRolesName { get; set; }
    }
}
