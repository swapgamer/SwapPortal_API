using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwapPortal_API.BLL.DTO;
using SwapPortal_API.DAL.Entities;
using SwapPortal_API.DAL.Repository.Interface;

namespace SwapPortal_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ApplicationController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IApplicationRepo applicationRepo;
        private readonly IJobListingRepo jobListingRepo;

        public ApplicationController(IMapper mapper, IApplicationRepo applicationRepo, IJobListingRepo jobListingRepo)
        {
            this.mapper = mapper;
            this.applicationRepo = applicationRepo;
            this.jobListingRepo = jobListingRepo;
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddAplicationRequestDTO addAplicationRequestDTO)
        {
            //Map DTO to Domain Model           
            var ApplicationEntity = mapper.Map<Application>(addAplicationRequestDTO);
            await applicationRepo.CreateAsync(ApplicationEntity);
            //Map domain model to DTO


            return Ok(mapper.Map<ApplicationDTO>(ApplicationEntity));
        }


        //GET Walks        
        //GET:/api/walks       


        [HttpPost]
        [Route("{jobId:int}/apply")]
        public async Task<IActionResult> ApplyForJob([FromRoute] int jobId, [FromBody] AddAplicationRequestDTO adApplicationRequestDTO)
        {
            var jobListingEntity = await jobListingRepo.GetByIdAsync(jobId);
            if (jobListingEntity == null)
            {
                return NotFound();
            }

            var applicationEntity = mapper.Map<Application>(adApplicationRequestDTO);
            applicationEntity.JobId = jobId;

            await applicationRepo.CreateAsync(applicationEntity);

            return Ok(mapper.Map<ApplicationDTO>(applicationEntity));
        }


        /*
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
         /*
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
                   var users = mapper.Map<UserDTO>(entityDeleted);
                   return Ok(users);

               }*/
    }
}
