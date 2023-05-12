using System;
using SharedProject.Contracts;

namespace RejuvenateHub.AppointmentBooking.Domain
{
	public class AppointmentScheduledEvent : IDomainEvent
    {
        public Appointment Appointment { get; set; }
    }


    public class AppointmentCancelledEvent : IDomainEvent
    {
        public Appointment Appointment { get; set; }
    }
}

