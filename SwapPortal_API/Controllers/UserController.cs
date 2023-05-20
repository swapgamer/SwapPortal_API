using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IApplicationRepo applicationRepo;

        public UserController(IMapper mapper, IUserRepo userRepo, IJobListingRepo jobListingRepo, IApplicationRepo applicationRepo)
        {
            this.mapper = mapper;
            this.userRepo = userRepo;
            this.applicationRepo = applicationRepo;
        }

        //Create User
        //Post:/api/users        


        //GET Walks        //GET:/api/walks       
        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            var userEntity = await userRepo.GetAllAsync();

            return Ok(mapper.Map<List<UserDTO>>(userEntity));
        }

        [HttpGet]
        [Route("{id:int}/admin")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var userEntity = await userRepo.GetByIdAsync(id);
            if (userEntity == null)
            {
                return NotFound();
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
                return NotFound();
            }
            return Ok(mapper.Map<UserDTO>(userEntity));
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

            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationDTO>>> GetAllApplicants()
        {
            var userEntity = await applicationRepo.GetAllAsync();

            return Ok(mapper.Map<List<ApplicationDTO>>(userEntity));
        }
    }
}


