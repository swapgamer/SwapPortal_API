using SwapPortal_API.DAL.Entities;

namespace SwapPortal_API.DAL.Repository.Interface
{
    public interface IJobListingRepo
    {
        Task<JobListing> CreateAsync(JobListing jobListing);
        Task<List<JobListing>> GetAllAsync();
        Task<JobListing> GetByIdAsync(int id);
        Task<JobListing> UpdateAsync(int id, JobListing jobListing);
        Task<JobListing> DeleteAsync(int id);
    }
}
