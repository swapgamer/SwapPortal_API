using Microsoft.EntityFrameworkCore;
using SwapPortal_API.DAL.Context;
using SwapPortal_API.DAL.Entities;
using SwapPortal_API.DAL.Repository.Interface;

namespace SwapPortal_API.DAL.Repository.Implementation
{

    public class ApplicationRepo : IApplicationRepo
    {
        private ApplicationDbContext dbContext;

        public ApplicationRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Application> CreateAsync(Application application)
        {
            await dbContext.Applications.AddAsync(application);
            await dbContext.SaveChangesAsync();
            return application;
        }

        public async Task<List<Application>> GetAllAsync()
        {
            return await dbContext.Applications.ToListAsync(); ;
        }

        public async Task<Application> GetByIdAsync(int id)
        {
            return await dbContext.Applications.FindAsync(id);
        }

        public async Task<List<Application>> GetByJobListingIdAsync(int jobListingId)
        {
            return await dbContext.Applications
           .Where(a => a.JobId == jobListingId)
           .ToListAsync();
        }

        public async Task UpdateAsync(Application application)
        {
            dbContext.Applications.Update(application);
            await dbContext.SaveChangesAsync();
        }
    }
}
