using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwapPortal_API.BLL.DTO;
using SwapPortal_API.DAL.Entities;
using SwapPortal_API.DAL.Repository.Interface;

namespace SwapPortal_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobListingController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IJobListingRepo jobListingRepo;

        //Creating Constructor
        public JobListingController(IMapper mapper, IJobListingRepo jobListingRepo)
        {
            this.mapper = mapper;
            this.jobListingRepo = jobListingRepo;
        }


        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddJobListingRequestDTO addJobListingRequestDTO)
        {
            //Map DTO to domain Model          
            var jobEntity = mapper.Map<JobListing>(addJobListingRequestDTO);
            await jobListingRepo.CreateAsync(jobEntity);
            //Domain Model to DTO


            return Ok(mapper.Map<JobListingDTO>(jobEntity));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobListingDTO>>> GetAll()
        {
            var userEntity = await jobListingRepo.GetAllAsync();

            return Ok(mapper.Map<List<JobListingDTO>>(userEntity));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var userEntity = await jobListingRepo.GetByIdAsync(id);
            if (userEntity == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<JobListingDTO>(userEntity));

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateJobListingDTO updateJobListingDTO)
        {
            var userEntity = mapper.Map<JobListing>(updateJobListingDTO);
            userEntity = await jobListingRepo.UpdateAsync(id, userEntity);
            if (userEntity == null)
            {
                return BadRequest();
            }

            return Ok(mapper.Map<JobListingDTO>(userEntity));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var entityDeleted = await jobListingRepo.DeleteAsync(id);
            if (entityDeleted == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
