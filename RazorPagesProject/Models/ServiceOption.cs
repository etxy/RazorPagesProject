using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesProject.Models
{
    public class ServiceOption
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public float Price { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
