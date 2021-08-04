using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesProject.Pages.Bookings
{
    public class BookingSummaryModel : PageModel
    {
        public string BookingInfo { get; set; }
        public string CustomerInfo { get; set; }
        public Models.Booking Booking { get; set; }
        public Models.Room Room { get; set; }
        public void OnPost()
        {
            CustomerInfo = "Name: " + Booking.CustomerName + "Contact Number: " + Booking.ContactNumber;
            BookingInfo = "\nStart Booking Date: " + Booking.CheckInDateTime.ToString() + "\nEnd Booking Date: " + 
                Booking.CheckOutDateTime.ToString() + "\nRoom Type: " + Room.RoomName;
        }
    }
}
