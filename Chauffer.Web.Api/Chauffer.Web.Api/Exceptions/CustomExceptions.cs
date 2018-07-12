using System;

namespace Chauffer.Web.Api.Exceptions
{
    public class BookingNotFoundException : Exception
    {
        public BookingNotFoundException()
        {
        }

        public BookingNotFoundException(string message)
        : base(message)
    {
        }

        public BookingNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
        }
    }

    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException()
        {
        }

        public CustomerNotFoundException(string message)
        : base(message)
        {
        }

        public CustomerNotFoundException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }

    public class DriverNotFoundException : Exception
    {
        public DriverNotFoundException()
        {
        }

        public DriverNotFoundException(string message)
        : base(message)
        {
        }

        public DriverNotFoundException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}