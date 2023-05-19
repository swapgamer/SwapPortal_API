using System.ComponentModel.DataAnnotations;

namespace SwapPortal_API.BLL.DTO
{
    public class AuthLoginResponseDTO
    {
        public int UserId { get; set; }
        public string token { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username must be between 1 and 50 characters.", MinimumLength = 1)]
        public string UserName { get; set; }
        public string UserRole { get; set; }
    }
}
