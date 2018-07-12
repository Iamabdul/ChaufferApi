using Chauffer.Web.Api.Models;

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
    }
}
