using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesProject.Models
{

    public class Booking
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public float TotalPrice { get; set; } 
        public int Quantity { get; set; }
        public string ServicesOption { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckInDateTime { get; set; } = System.DateTime.Now;
        [DataType(DataType.Date)]
        public DateTime CheckOutDateTime { get; set; } = System.DateTime.Now;

        public virtual Room Room { get; set; }
    } 
}
