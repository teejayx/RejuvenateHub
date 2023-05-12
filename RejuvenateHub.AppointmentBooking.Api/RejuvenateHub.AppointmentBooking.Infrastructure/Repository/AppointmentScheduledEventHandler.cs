using System;
using RejuvenateHub.AppointmentBooking.Domain;
using SharedProject.Contracts;

namespace RejuvenateHub.AppointmentBooking.Infrastructure.Repository
{
    public class AppointmentScheduledEventHandler : IDomainEventHandler<AppointmentScheduledEvent>
    {
        public void Handle(AppointmentScheduledEvent @event)
        {
            Console.WriteLine($"Appointment scheduled: {@event.Appointment.Id}");
        }
    }

    public class AppointmentCancelledEventHandler : IDomainEventHandler<AppointmentCancelledEvent>
    {
        public void Handle(AppointmentCancelledEvent @event)
        {
            Console.WriteLine($"Appointment cancelled: {@event.Appointment.Id}");
        }
    }
}

