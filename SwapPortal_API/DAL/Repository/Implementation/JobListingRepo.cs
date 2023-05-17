using Microsoft.EntityFrameworkCore;
using SwapPortal_API.DAL.Context;
using SwapPortal_API.DAL.Entities;
using SwapPortal_API.DAL.Repository.Interface;

namespace SwapPortal_API.DAL.Repository.Implementation
{

    public class JobListingRepo : IJobListingRepo
    {
        private readonly ApplicationDbContext dbContext;

        public JobListingRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<JobListing> CreateAsync(JobListing jobListing)
        {
            await dbContext.JobListings.AddAsync(jobListing);
            await dbContext.SaveChangesAsync();
            return jobListing;
        }

        public async Task<List<JobListing>> GetAllAsync()
        {
            return await dbContext.JobListings.Include("User").ToListAsync();
        }

        public async Task<JobListing> GetByIdAsync(int id)
        {
            return await dbContext.JobListings.Include("User").FirstOrDefaultAsync(x => x.JobId == id);
        }
        public async Task<JobListing> UpdateAsync(int id, JobListing jobListing)
        {
            var existingJob = await dbContext.JobListings.FirstOrDefaultAsync(x => x.JobId == id);
            if (existingJob == null)
            {
                return null;
            }

            existingJob.JobTitle = jobListing.JobTitle;
            existingJob.JobDesc = jobListing.JobDesc;
            existingJob.DatePosted = jobListing.DatePosted;
            existingJob.Salary = jobListing.Salary;


            await dbContext.SaveChangesAsync();
            return existingJob;
        }
        public async Task<JobListing> DeleteAsync(int id)
        {
            var existingJob = await dbContext.JobListings.FirstOrDefaultAsync(x => x.JobId == id);
            if (existingJob == null)


            {
                return null;
            }
            dbContext.JobListings.Remove(existingJob);

            await dbContext.SaveChangesAsync();
            return existingJob;
        }
    }
}
