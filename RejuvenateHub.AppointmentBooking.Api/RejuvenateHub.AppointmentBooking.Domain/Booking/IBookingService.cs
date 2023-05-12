using System;
using SharedProject.Contracts;

namespace RejuvenateHub.AppointmentBooking.Domain
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Appointment>> GetAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(Guid id);
        Task<Appointment> ScheduleAppointmentAsync(Appointment appointment, IEventBus eventBus);
        Task CancelAppointmentAsync(Guid id, IEventBus eventBus);
        IQueryable<Appointment> GetOrder();
        Task<int> GetAvailableResourceCountAsync(int branchId);
    }

}