using System;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
using RejuvenateHub.AppointmentBooking.Domain;
using RejuvenateHub.AppointmentBooking.Infrastructure.Repository;
using SharedProject.Contracts;
using SharedProject.Dapper;

namespace RejuvenateHub.AppointmentBooking.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddTransient<IDbConnection>(sp => new SqlConnection(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IRepository<Appointment>, DapperRepository<Appointment>>();
            services.AddSingleton<IEventBus, InMemoryEventBus>();
            services.AddTransient<IBookingRepository, BookingRepository>();

            // Register event handlers
            services.AddTransient<IDomainEventHandler<AppointmentScheduledEvent>, AppointmentScheduledEventHandler>();
            services.AddTransient<IDomainEventHandler<AppointmentCancelledEvent>, AppointmentCancelledEventHandler>();
        }

    }
}

