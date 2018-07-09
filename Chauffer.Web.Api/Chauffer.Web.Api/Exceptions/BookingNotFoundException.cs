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
}