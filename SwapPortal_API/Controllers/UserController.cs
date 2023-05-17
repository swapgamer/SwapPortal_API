using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwapPortal_API.BLL.DTO;
using SwapPortal_API.DAL.Entities;
using SwapPortal_API.DAL.Repository.Interface;

namespace SwapPortal_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserRepo userRepo;

        public UserController(IMapper mapper, IUserRepo userRepo)
        {
            this.mapper = mapper;
            this.userRepo = userRepo;
        }

        //Create User
        //Post:/api/users        
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddUserRequestDTO addUserRequestDTO)
        {
            //Map DTO to Domain Model           
            var userEntity = mapper.Map<User>(addUserRequestDTO);
            await userRepo.CreateAsync(userEntity);
            var users = mapper.Map<UserDTO>(userEntity);

            return Ok(users);
        }

        //GET Walks        //GET:/api/walks       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userEntity = await userRepo.GetAllAsync();

            return Ok(mapper.Map<List<UserDTO>>(userEntity));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var userEntity = await userRepo.GetByIdAsync(id);
            if (userEntity == null)
            {
                return BadRequest();
            }
            var users = mapper.Map<UserDTO>(userEntity);
            return Ok(users);

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateUserRequestDTO updateUserRequestDTO)
        {
            var userEntity = mapper.Map<User>(updateUserRequestDTO);
            userEntity = await userRepo.UpdateAsync(id, userEntity);
            if (userEntity == null)
            {
                return BadRequest();
            }
            var users = mapper.Map<UserDTO>(userEntity);
            return Ok(users);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var entityDeleted = await userRepo.DeleteAsync(id);
            if (entityDeleted == null)
            {
                return NotFound();
            }

            return Ok("Deleted");
        }
    }
}


