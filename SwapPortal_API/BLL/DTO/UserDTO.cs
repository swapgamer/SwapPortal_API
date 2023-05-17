namespace SwapPortal_API.BLL.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }


        public string Email { get; set; }


        public string Password { get; set; }


        public string FName { get; set; }


        public string LName { get; set; }



        public UserRoleDTO UserRole { get; set; }
    }
}
