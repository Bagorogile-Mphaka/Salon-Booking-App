using System;
using System.ComponentModel.DataAnnotations;

namespace SalonBookingApp1.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage="Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage="Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Phone Number is required")]
        public string PhoneNumber { get; set; }

        public List<Bookings> Bookings { get; set; }


        // Parameterized constructor
        public Client(int clientId, string name, string lastName,string email, string phoneNumber, List<Bookings> bookings)
        {
            Id = clientId;
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Bookings = bookings;
        }
    }
}
