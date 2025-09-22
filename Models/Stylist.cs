using System;
using System.ComponentModel.DataAnnotations;
namespace SalonBookingApp1.Models
{
    public class Stylist
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }



        public Stylist(Guid stylistId, string name, string email, string lastName)
        {
            Id = stylistId;
            Name = name;
            LastName = lastName;
            Email = email;
        }
    }
}     
