using System;
using System.ComponentModel.DataAnnotations;

namespace SalonBookingApp1.Models
{
    public class Clients
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


        // Parameterized constructor
        public Clients(int clientId, string name, string lastName,string email, string phoneNumber)
        {
            Id = clientId;
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
