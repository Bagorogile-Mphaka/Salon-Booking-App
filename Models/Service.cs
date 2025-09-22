using System;
using System.ComponentModel.DataAnnotations;

namespace SalonBookingApp1.Models
{
    public class Service
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Service Name is required")]
        public string ServiceName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        decimal Price { get; set; }

        // Parameterised constructor    
        public Service( Guid serviceId, string serviceName, decimal price)
        {
            Id = serviceId;
            ServiceName = serviceName;
            Price = price;
            
            
        }
        
    }
}
