﻿using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwapPortal_API.BLL.DTO;
using SwapPortal_API.DAL.Context;
using SwapPortal_API.DAL.Entities;
using SwapPortal_API.DAL.Repository.Interface;
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
        private readonly IMapper mapper;
        private readonly IUserRepo userRepo;

        public AuthController(ApplicationDbContext context, IConfiguration configuration, IMapper mapper, IUserRepo userRepo)
        {
            this.context = context;
            this.configuration = configuration;
            this.mapper = mapper;
            this.userRepo = userRepo;

        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login(AddAuthUserLoginDTO loginModel)
        {

            var user = context.Users.Include(x => x.UserRole).SingleOrDefault(x => x.Email == loginModel.Email);

            if (user is null)
                return Unauthorized("Invalid Username or Password!");

            string hashedPassword = HashPassword(loginModel.Password);
            if (BCrypt.Net.BCrypt.Verify(loginModel.Password, user.Password))
            {

                var token = JWT.GenerateToken(new Dictionary<string, string> {
                { ClaimTypes.Role, user.UserRole.UserRolesName  },
                { "RoleId", user.UserRole.UserRoleId.ToString() },
                {JwtClaimTypes.PreferredUserName, user.UserName },
                { JwtClaimTypes.Id, user.UserId.ToString() },
                { JwtClaimTypes.Email, user.Email}
            }, configuration["JWT:Key"]);



                return Ok(new AddAuthResponseDTO { token = token, UserName = user.UserName });
            }
            else
            {
                return Unauthorized("Invalid Username or Password");
            }
        }
        [Route("Registration")]
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddUserRequestDTO addUserRequestDTO)
        {

            // Check if a user with the same email already exists
            var existingUser = await userRepo.GetByEmailAsync(addUserRequestDTO.Email);
            if (existingUser != null)
            {
                // Return an error response indicating that the email is already registered
                return BadRequest("Email is already registered.");
            }
            //Map DTO to Domain Model           
            var userEntity = mapper.Map<User>(addUserRequestDTO);
            userEntity.Password = HashPassword(addUserRequestDTO.Password);



            await userRepo.CreateAsync(userEntity);
            // var users = mapper.Map<UserDTO>(userEntity);

            return Ok("Registration Successful");
        }
        private string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }
    }
}

