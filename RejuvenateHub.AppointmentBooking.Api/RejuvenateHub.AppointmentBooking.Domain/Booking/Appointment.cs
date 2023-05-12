using System;
using SharedProject.Seedworks;

namespace RejuvenateHub.AppointmentBooking.Domain
{
    public class Appointment : BaseEntity<Guid, Guid>
    {
        public DateTime AppointmentDate { get; set; }
        public TimeSpan Duration { get; set; }
        public ServiceType Service { get; set; }
        public int BranchId { get; set; }
        public Guid ClientId { get; set; }
        public AppointmentStatus Status { get; set; }
        // Resource allocation
        public int NumberOfResources { get; set; }
    }

}

