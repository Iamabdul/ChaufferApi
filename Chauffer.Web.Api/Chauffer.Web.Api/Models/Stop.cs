using System;

namespace Chauffer.Web.Api.Models
{
    public class Stop
    {
        public string StopId { get; set; }
        public string BookingId { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public DateTime Date { get; set; }
        public StopReason Reason { get; set; }
        public decimal Charge { get; set; }
    }
    public enum StopReason
    {
        Standard,
        Emergency
    }
}