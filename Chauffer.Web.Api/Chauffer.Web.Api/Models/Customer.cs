namespace Chauffer.Web.Api.Models
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string PreferredDriverUserId { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public string ExtraInformation { get; set; }
        public string Email { get; set; }
    }
}