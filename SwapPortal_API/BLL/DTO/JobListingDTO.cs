using SwapPortal_API.DAL.Entities;

namespace SwapPortal_API.BLL.DTO
{
    public class JobListingDTO
    {

        public int JobId { get; set; }

        public string JobTitle { get; set; }


        public string JobDesc { get; set; }

        public DateTime DatePosted { get; set; }


        public int UserId { get; set; }
        public virtual User User { get; set; }

        public string CompanyName { get; set; }


        public int Salary { get; set; }

    }
}
