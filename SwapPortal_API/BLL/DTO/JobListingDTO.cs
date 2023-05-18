using SwapPortal_API.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace SwapPortal_API.BLL.DTO
{
    public class JobListingDTO
    {

        public int JobId { get; set; }
        [Required(ErrorMessage = "Job title is required.")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Job description is required.")]

        public string JobDesc { get; set; }

        public DateTime DatePosted { get; set; }


        public int UserId { get; set; }
        public virtual User User { get; set; }

        public string CompanyName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]

        public int Salary { get; set; }

    }
}
