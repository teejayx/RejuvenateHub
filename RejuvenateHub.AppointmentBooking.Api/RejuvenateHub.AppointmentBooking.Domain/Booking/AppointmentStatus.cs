using System;
using SharedProject.Seedworks;

namespace RejuvenateHub.AppointmentBooking.Domain
{
    public class AppointmentStatus : Enumeration
    {
        public static AppointmentStatus Scheduled = new AppointmentStatus(1, nameof(Scheduled).ToLowerInvariant());
        public static AppointmentStatus Confirmed = new AppointmentStatus(2, nameof(Confirmed).ToLowerInvariant());
        public static AppointmentStatus Cancelled = new AppointmentStatus(3, nameof(Cancelled).ToLowerInvariant());
        public static AppointmentStatus Completed = new AppointmentStatus(4, nameof(Completed).ToLowerInvariant());
        public static AppointmentStatus Rescheduled = new AppointmentStatus(5, nameof(Rescheduled).ToLowerInvariant());
        public static AppointmentStatus Hold = new AppointmentStatus(6, nameof(Hold).ToLowerInvariant());

        public AppointmentStatus(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<AppointmentStatus> List() =>
            new[] { Scheduled, Confirmed, Cancelled, Completed, Rescheduled, Hold };

        public static AppointmentStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new AppointMentDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static AppointmentStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new AppointMentDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}

