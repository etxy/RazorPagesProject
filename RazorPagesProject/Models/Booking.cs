using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace RazorPagesProject.Models
{
    public class Booking
    {
        public int ID { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "You must enter your name")]
        public string CustomerName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "You must enter your contact number")]
        public string ContactNumber { get; set; }
        public float TotalPrice { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "You must enter the number of room(s) you want to book")]
        public int Quantity { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "You must enter the number of days of your stay")]
        public int NumOfDays { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter the check-in date time you want to book")]
        public DateTime CheckInDateTime { get; set; } = System.DateTime.Now;
        [DataType(DataType.Date)]
        public DateTime CheckOutDateTime { get; set; } = System.DateTime.Now;

        public virtual Room Room { get; set; }
        public ICollection<ServiceOption> ServiceOptions { get; set; } = new List<ServiceOption>();
    }
}
