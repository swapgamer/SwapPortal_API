using Microsoft.EntityFrameworkCore;
using SwapPortal_API.DAL.Entities;

namespace SwapPortal_API.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<JobListing> JobListings { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserRole>().HasData(
        new UserRole
        {
            UserRoleId = 1, // Update with the correct primary key value
            UserRolesName = "Recruiter"
        },
        new UserRole
        {
            UserRoleId = 2, // Update with the correct primary key value
            UserRolesName = "Applicant"
        },
         new UserRole
         {
             UserRoleId = 3, // Update with the correct primary key value
             UserRolesName = "Admin"
         }
        );

        }
    }
}