using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwapPortal_API.DAL.Entities
{
    public class JobListing
    {

        [Key]
        public int JobId { get; set; }

        [Required(ErrorMessage = "Job title is required.")]
        [MaxLength(50)]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Job description is required.")]
        [MaxLength(200)]
        public string JobDesc { get; set; }

        [Required]
        public DateTime DatePosted { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public decimal Salary { get; set; }





    }
}
