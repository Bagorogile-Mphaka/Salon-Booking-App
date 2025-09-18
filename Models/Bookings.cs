using System;

namespace SalonBookingApp1.Models
{
    public class Bookings
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid StylistId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime BookingDate { get; set; }
        public BookingStatus Status { get; set; }

        //Default constructor
        public Bookings()
        {
            
            BookingDate = DateTime.Now;
            Status = BookingStatus.Pending;
        }

        public enum BookingStatus
        {
            Pending,
            Confirmed,
            Completed,
            Cancelled
        }
        //Parameterized constructor
        public Bookings(Guid clientId, Guid stylistId, Guid serviceId, DateTime bookingDate, BookingStatus status)
        {
            Id = this.Id;
            ClientId = clientId;
            StylistId = stylistId;
            ServiceId = serviceId;
            BookingDate = bookingDate;
            Status = status;
        }

    }
}
