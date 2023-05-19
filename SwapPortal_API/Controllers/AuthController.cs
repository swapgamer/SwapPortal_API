using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwapPortal_API.BLL.DTO;
using SwapPortal_API.DAL.Context;
using SwapPortal_API.DAL.Entities;
using SwapPortal_API.Infrastructure;
using System.Security.Claims;


namespace SwapPortal_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ApplicationDbContext context;
        private readonly IConfiguration configuration;
        private IMapper mapper;

        public AuthController(ApplicationDbContext context, IConfiguration configuration, IMapper mapper)
        {
            this.context = context;
            this.configuration = configuration;
            this.mapper = mapper;
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login(AddLoginRequestDTO addLoginRequestDTO)
        {
            var hashedPass = addLoginRequestDTO.Password;
            User user = context.Users.Include(x => x.UserRole).SingleOrDefault(x => x.Email == addLoginRequestDTO.Email && x.Password == hashedPass);

            if (user is null)
                return Unauthorized("Invalid Username or Password!");

            string role;
            var token = JWT.GenerateToken(new Dictionary<string, string> {
                { ClaimTypes.Role, user.UserRole.UserRolesName  },
                { "RoleId", user.UserRole.UserRoleId.ToString() },
                {ClaimTypes.Name, user.UserName },
                { "UserId", user.UserId.ToString() },
                { ClaimTypes.Email, user.Email}
            }, configuration["JWT:Key"]);

            if (user.UserRoleId == 1)
            {
                role = "Recruiter";
            }
            else
            {
                role = "Applicant";
            }


            return Ok(new AuthLoginResponseDTO { UserId = user.UserId, token = token, UserName = user.UserName, UserRole = role });
        }
    }
}

