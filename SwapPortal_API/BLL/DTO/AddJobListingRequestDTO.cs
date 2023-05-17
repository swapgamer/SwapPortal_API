namespace SwapPortal_API.BLL.DTO
{
    public class AddJobListingRequestDTO
    {
        public string JobTitle { get; set; }


        public string JobDesc { get; set; }


        public DateTime DatePosted { get; set; }


        public int UserId { get; set; }



        public string CompanyName { get; set; }


        public int Salary { get; set; }
    }
}
