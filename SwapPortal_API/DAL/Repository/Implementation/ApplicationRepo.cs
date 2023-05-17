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

    }
}
