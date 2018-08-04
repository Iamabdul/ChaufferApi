using Chauffer.Web.Api.Models;
using System;

namespace Chauffer.Web.Api.Tests
{
    public static class CommonDataSet
    {
        public static RegisterBindingModel RegisterBindingModel { get; } = new RegisterBindingModel
        {
            PhoneNumber = "USERPhoneNumber",
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

        public static Customer CommonCustomer { get; } = new Customer
        {
            PhoneNumber = new PhoneNumber
            {
            },
            Address = "22 Address to success",
            FirstName = "BEEKO",
            LastName = "TEEKO",
            PreferredName = "WhatsmyNICKNAME",
            PostCode = "123rdf",
            ExtraInformation = "extra info",
            Email = "email@email.email"
        };

        public static Driver CommonDriver { get; } = new Driver
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

        public static Booking CommonBooking { get; } = new Booking
        {
            BookingId = "NewBookingID",
            CustomerId = CommonCustomer.CustomerId,
            DriverId = CommonDriver.DriverId,
            CreatedDate = DateTime.UtcNow,
            StartAddress = "NewBookingStartAddress",
            StartPostCode = "NewBookingStartPostCode",
            EndAddress = "NewBookingEndAddress",
            EndPostCode = "NewBookingEndPostCode",
            CompletedDate = DateTime.UtcNow.AddHours(4),
            JobType = JobType.AsDirected,
            ExtraInformation = "NewBookingExtraInformation"
        };
        public static BookingBindingModel BookingBindingModel { get; } = new BookingBindingModel
        {
            BookingId = "NewBookingID",
            CustomerId = "NewBookingCustomerID",
            DriverId = CommonDriver.DriverId,
            CreatedDate = DateTime.UtcNow,
            StartAddress = "NewBookingStartAddress",
            StartPostCode = "NewBookingStartPostCode",
            EndAddress = "NewBookingEndAddress",
            EndPostCode = "NewBookingEndPostCode",
            CompletedDate = DateTime.UtcNow.AddHours(4),
            JobType = JobType.AsDirected,
            ExtraInformation = "NewBookingExtraInformation"
        };

        public static StopBindingModel StopBindingModel { get; } = new StopBindingModel
        {
            Address = "NewStopAddress",
            BookingId = CommonBooking.BookingId,
            PostCode = "NewStopAddress",
            Reason = StopReason.Standard
        };

        public static CustomerBindingModel CustomerBindingModel { get; } = new CustomerBindingModel
        {
            PreferredDriverUserId = "preferredDriverUserID",
            PhoneNumber = new PhoneNumber { },
            Address = "22 Address to success",
            FirstName = "BEEKO",
            LastName = "TEEKO",
            PreferredName = "WhatsmyNICKNAME",
            PostCode = "123rdf",
            ExtraInformation = "extra info",
            Email = "email@email.email"
        };
    }
}
