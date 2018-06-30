﻿namespace Chauffer.Web.Api.Models
{
    public class Driver
    {
        public string DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public string LiscenceNumber { get; set; }
        public CarType CarType { get; set; }
        public string CarDetails { get; set; }
    }
}