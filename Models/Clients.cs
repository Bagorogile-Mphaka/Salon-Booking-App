using System;
using System.ComponentModel.DataAnnotations;

namespace SalonBookingApp1.Models
{
    public class Clients
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage="Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage="Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Phone Number is required")]
        public string PhoneNumber { get; set; }

        // Default constructor
        public Clients()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
        }
        // Parameterized constructor
        public Clients(Guid clientId, string name, string email, string phoneNumber)
        {
            Id = clientId;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
