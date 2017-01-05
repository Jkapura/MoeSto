namespace MoeSto.Web.Models.DtoObjects
{
    public class CompanyDetailsDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phones { get; set; }
        public byte[] MainImage { get; set; }
    }
}