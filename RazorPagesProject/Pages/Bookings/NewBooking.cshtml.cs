using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesProject.Data;
using RazorPagesProject.Models;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesProject.Pages.Bookings
{
    public class NewBookingModel : PageModel
    {
        private readonly RazorPagesProject.Data.RazorPagesProjectContext _context;

        public NewBookingModel(RazorPagesProject.Data.RazorPagesProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Room> Rooms { get; set; }

        public string BookingInfo { get; set; }
        public string CustomerInfo { get; set; }
        [BindProperty]
        public Booking Booking { get; set; }
        [BindProperty]
        public Room Room { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You must enter your name")]
        public string CustomerName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "You must enter your contact number")]
        public string ContactNumber { get; set; }

        [BindProperty]
        public bool BreakfastBuffet { get; set; }
        [BindProperty]
        public bool Balcony { get; set; }
        [BindProperty]
        public bool SeaView { get; set; }
        [BindProperty]
        public bool ExtraBed { get; set; }
        public string Message { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (Room.RoomName == "Superior")
                {
                    Booking.TotalPrice = Room.Price;
                }
                else if (Room.RoomName == "Deluxe")
                {
                    Booking.TotalPrice = Room.Price;
                }
                else if (Room.RoomName == "Adjoining")
                {
                    Booking.TotalPrice = Room.Price;
                }
                else if (Room.RoomName == "Suite")
                {
                    Booking.TotalPrice = Room.Price;
                }
                else if (Room.RoomName == "Family")
                {
                    Booking.TotalPrice = Room.Price;
                }

                if (BreakfastBuffet == true)
                {
                    BookingInfo += " with breakfast buffet";
                    Booking.TotalPrice += 30;
                }
                if (Balcony == true)
                {
                    BookingInfo += " with balcony";
                    Booking.TotalPrice += 100;
                }
                if (SeaView == true)
                {
                    BookingInfo += " with sea view";
                    Booking.TotalPrice += 50;
                }
                if (ExtraBed == true)
                {
                    BookingInfo += " add extra bed";
                    Booking.TotalPrice += 50;
                }
                if (Booking.CheckInDateTime > System.DateTime.Now.AddDays(60))
                {
                    Message = "Booking of rooms 60 days ahead gives you 10% discount!";
                    Booking.TotalPrice = Booking.TotalPrice * 0.9f;
                }
                CustomerInfo = "Name: " + Booking.CustomerName + "Contact Number: " + Booking.ContactNumber;
                BookingInfo = "\nStart Booking Date: " + Booking.CheckInDateTime.ToString() + "\nEnd Booking Date: " + Booking.CheckOutDateTime.ToString() + "\nRoom Type: " + Room.RoomName;

                _context.Booking.Add(Booking);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }
        public async Task OnGetAsync()
        {
            Rooms = await _context.Room.ToListAsync();
        }
    }
}
