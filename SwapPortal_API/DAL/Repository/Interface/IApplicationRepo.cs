using SwapPortal_API.DAL.Entities;

namespace SwapPortal_API.DAL.Repository.Interface
{
    public interface IApplicationRepo
    {
        Task<Application> CreateAsync(Application application);
        Task<List<Application>> GetAllAsync();
        Task<List<Application>> GetByJobListingIdAsync(int jobListingId);
        Task<Application> GetByIdAsync(int id);
        Task UpdateAsync(Application application);

    }
}
