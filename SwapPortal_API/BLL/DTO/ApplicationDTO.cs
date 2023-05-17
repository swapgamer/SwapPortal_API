namespace SwapPortal_API.BLL.DTO
{
    public class ApplicationDTO
    {
        public int ApplicationId { get; set; }


        public DateTime ApplicationDate { get; set; }


        public string Status { get; set; }




        public virtual UserDTO User { get; set; }




        public virtual JobListingDTO JobListing { get; set; }


        public string ResumeLink { get; set; }
    }
}
