namespace Chauffer.Web.Api.Models
{
    public class StopModel
    {
        public string BookingId { get; set; }
        public StopReason Reason { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
    }
}