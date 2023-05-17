using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwapPortal_API.DAL.Entities
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }


        public virtual User User { get; set; }

        [Required]
        [ForeignKey("JobId")]
        public int JobId { get; set; }


        public virtual JobListing JobListing { get; set; }

        [Required]
        [MaxLength(100)]
        public string ResumeLink { get; set; }
    }
}
