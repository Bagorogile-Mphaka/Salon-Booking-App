using System;
using System.ComponentModel.DataAnnotations;

namespace SalonBookingApp1.Models
{
    public class Treatment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Treatment Name is required")]
        public string TreatmentName { get; set; }

        [Required(ErrorMessage = "Price name is required")]
        decimal Price { get; set; }

        // Parameterised constructor    
        public Treatment( int treatmentId, string treatmentName, decimal price)
        {
            Id = treatmentId;
            TreatmentName = treatmentName;
            Price = price;
            
            
        }
        
    }
}
