using System;
using SharedProject.Domain.Enum;
using SharedProject.Seedworks;

namespace RejuvenateHub.AppointmentBooking.Domain.Booking
{
    public class Booking : BaseEntity<Guid, Guid>
    {
        public Guid CustomerId { get; set; }
        public List<Appointment> Appointments { get; set; }
        public bool IsConfirmed { get; set; }
        public decimal TotalAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}

