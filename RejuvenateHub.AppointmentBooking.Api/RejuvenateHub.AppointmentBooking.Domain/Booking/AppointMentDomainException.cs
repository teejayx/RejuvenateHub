using System;
namespace RejuvenateHub.AppointmentBooking.Domain
{
	public class AppointMentDomainException : Exception
    {
        public AppointMentDomainException()
        { }

        public AppointMentDomainException(string message)
            : base(message)
        { }

        public AppointMentDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

