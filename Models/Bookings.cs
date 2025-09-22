using System;
using System.ComponentModel.DataAnnotations;

namespace SalonBookingApp1.Models
{
    public class Bookings
    {
        public Guid Id { get; set; }
        public int ClientId { get; set; }
        public int StylistId { get; set; }
        public int TreatmentId { get; set; }

        [Required (ErrorMessage="Booking Date is required")]
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
        public Bookings(Guid bookingId,int clientId, int stylistId, int treatmentId, DateTime bookingDate, BookingStatus status)
        {
            Id = bookingId;
            ClientId = clientId;
            StylistId = stylistId;
            TreatmentId = treatmentId;
            BookingDate = bookingDate;

            Status = status;
        }

    }
}
