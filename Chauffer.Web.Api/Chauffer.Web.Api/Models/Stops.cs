namespace Chauffer.Web.Api.Models
{
    public class Stops
    {
        public string StopId { get; set; }
        public string BookingId { get; set; }
        public string StopAddress { get; set; }
        public string StopPostCode { get; set; }
        public StopReason StopReason { get; set; }
    }
    public enum StopReason
    {
        Standard,
        Emergency
    }
}