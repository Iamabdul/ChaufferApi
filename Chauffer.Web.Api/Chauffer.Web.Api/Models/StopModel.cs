using System;

namespace Chauffer.Web.Api.Models
{
    public class StopBindingModel
    {
        public string BookingId { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public StopReason Reason { get; set; }
        public DateTime Date { get; set; }
    }
}