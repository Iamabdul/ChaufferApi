using System;

namespace Chauffer.Web.Api.Models
{
    public class Booking
    {
        public string BookingId { get; set; }
        public string CustomerId { get; set; }
        public string DriverId { get; set; }
        public string StartAddress { get; set; }
        public string StartPostCode { get; set; }
        public string EndAddress { get; set; }
        public string EndPostCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public JobType JobType { get; set; }
        public string ExtraInformation { get; set; }
    }
}