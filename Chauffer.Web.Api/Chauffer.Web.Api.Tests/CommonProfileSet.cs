using Chauffer.Web.Api.Models;
using System;

namespace Chauffer.Web.Api.Tests
{
    public static class CommonDataSet
    {
        public static RegisterBindingModel registerBindingModel { get; } = new RegisterBindingModel
        {
            PreferredDriverUserId = "preferredDriverUserID",
            PhoneNumber = new PhoneNumber { },
            Address = "22 Address to success",
            Password = "password" ,
            ConfirmPassword = "password",
            FirstName = "BEEKO",
            LastName = "TEEKO",
            PreferredName = "WhatsmyNICKNAME", 
            PostCode = "123rdf",
            ExtraInformation = "extra info",
            Email = "email@email.email"
        };

        public static Driver commonDriver { get; } = new Driver
        {
            DriverId = "DriverID",
            FirstName = "DriverFirstName",
            LastName = "DriverLastName",
            PreferredName = "DriverPrefferedName",
            Address = "DriverAddress",
            PostCode = "DriverPostCode",
            PhoneNumber = new PhoneNumber
            {
                MobilePhone = "DriverMobilePhone"
            },
            CarDetails = "DriverDetails",
            CarType = CarType.Luxury,
            LicenceNumber = "DriverLiscenceNumber",
            IsActive = true
        };

        public static Booking commonBooking { get; } = new Booking
        {
            BookingId = "NewBookingID",
            CustomerId = "NewBookingCustomerID",
            DriverId = "NewBookingDriverID",
            CreatedDate = DateTime.UtcNow,
            StartAddress = "NewBookingStartAddress",
            StartPostCode = "NewBookingStartPostCode",
            EndAddress = "NewBookingEndAddress",
            EndPostCode = "NewBookingEndPostCode",
            CompletedDate = DateTime.UtcNow.AddHours(4),
            JobType = JobType.AsDirected,
            ExtraInformation = "NewBookingExtraInformation"
        };
        public static BookingBindingModel bookingBindingModel { get; } = new BookingBindingModel
        {
            BookingId = "NewBookingID",
            CustomerId = "NewBookingCustomerID",
            DriverId = "NewBookingDriverID",
            CreatedDate = DateTime.UtcNow,
            StartAddress = "NewBookingStartAddress",
            StartPostCode = "NewBookingStartPostCode",
            EndAddress = "NewBookingEndAddress",
            EndPostCode = "NewBookingEndPostCode",
            CompletedDate = DateTime.UtcNow.AddHours(4),
            JobType = JobType.AsDirected,
            ExtraInformation = "NewBookingExtraInformation"
        };

        public static StopBindingModel stopBindingModel { get; } = new StopBindingModel
        {
            Address = "NewStopAddress",
            BookingId = "NewBookingID",
            PostCode = "NewStopAddress",
            Reason = StopReason.Standard
        };
    }
}
