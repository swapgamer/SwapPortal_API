using Microsoft.EntityFrameworkCore;
using SwapPortal_API.DAL.Context;
using SwapPortal_API.DAL.Entities;
using SwapPortal_API.DAL.Repository.Interface;

namespace SwapPortal_API.DAL.Repository.Implementation
{
    public class UserRepo : IUserRepo
    {
        private ApplicationDbContext dbContext;

        public UserRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var existingUsers = await dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (existingUsers == null)
            {
                return null;
            }
            dbContext.Users.Remove(existingUsers);
            await dbContext.SaveChangesAsync();
            return existingUsers;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.Include("UserRole").ToListAsync();

        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await dbContext.Users.Include("UserRole").FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.FName = user.FName;
            existingUser.LName = user.LName;
            existingUser.UserRoleId = user.UserRoleId;

            await dbContext.SaveChangesAsync();
            return existingUser;
        }
    }
}
