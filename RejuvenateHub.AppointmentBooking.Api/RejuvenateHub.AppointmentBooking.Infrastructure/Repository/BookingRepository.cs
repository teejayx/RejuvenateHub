using System;
using RejuvenateHub.AppointmentBooking.Domain;
using SharedProject.Contracts;
using SharedProject.Dapper;

namespace RejuvenateHub.AppointmentBooking.Infrastructure.Repository
{
    public class BookingRepository :  IBookingRepository
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IResourceAvailabilityRepository _resourceAvailabilityRepository;

        public BookingRepository(IRepository<Appointment> appointmentRepository, IResourceAvailabilityRepository resourceAvailabilityRepository)
        {
            _appointmentRepository = appointmentRepository;
            _resourceAvailabilityRepository = resourceAvailabilityRepository;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync()
        {
            return await _appointmentRepository.GetAllAsync();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(Guid id)
        {
            return await _appointmentRepository.GetByIdAsync(id);
        }

        public async Task<Appointment> ScheduleAppointmentAsync(Appointment appointment, IEventBus eventBus)
        {
            // Additional business logic to validate and process the appointment before scheduling.

            await _appointmentRepository.AddAsync(appointment);

            // Decrement available resource count
            await _resourceAvailabilityRepository.DecrementAvailableResourcesAsync(appointment.BranchId, appointment.NumberOfResources);



            // Raise the AppointmentScheduled event
            eventBus.Publish(new AppointmentScheduledEvent { Appointment = appointment });
            return appointment;
        }

        public async Task<Appointment> UpdateAppointmentAsync(Guid id, Appointment appointment)
        {
            // Additional business logic to validate and process the appointment before updating.

            appointment.Id = id;
            await _appointmentRepository.UpdateAsync(appointment);
            return appointment;
        }

        public async Task CancelAppointmentAsync(Guid id, IEventBus eventBus)
        {
            // Additional business logic to validate and process the appointment before cancelling.

            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {id} not found.");
            }

            // Increment available resource count
            await _resourceAvailabilityRepository.IncrementAvailableResourcesAsync(appointment.BranchId, appointment.NumberOfResources);


            appointment.Status = AppointmentStatus.Cancelled;
            await _appointmentRepository.UpdateAsync(appointment);
            // Raise the AppointmentCancelled event
            eventBus.Publish(new AppointmentCancelledEvent { Appointment = appointment });
        }

        public IQueryable<Appointment> GetOrder()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetAvailableResourceCountAsync(int branchId)
        {
            return await _resourceAvailabilityRepository.GetAvailableResourcesAsync(branchId);
        }
    }

}

