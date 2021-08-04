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
        public BookingVm BookingVm { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var getFirstRoom =await _context.Room.FirstOrDefaultAsync(x => x.Id == BookingVm.BookingRoomId);

                var booking = new Booking()
                {
                    CustomerName = BookingVm.Booking.CustomerName,
                    ContactNumber =BookingVm.Booking.ContactNumber,
                    CheckInDateTime = BookingVm.Booking.CheckInDateTime,
                    CheckOutDateTime = BookingVm.Booking.CheckOutDateTime,

                    Quantity = BookingVm.Booking.Quantity,
                    ServicesOption = BookingVm.Booking.ServicesOption,
                    TotalPrice = BookingVm.Booking.TotalPrice,
                    Room = getFirstRoom
                };


                _context.Booking.Add(booking);
                await _context.SaveChangesAsync();
            }
            return Redirect("~/");


        }
        public async Task OnGetAsync()
        {
            var rooms = await _context.Room.ToListAsync();
            var model = new BookingVm();

            foreach (var room in rooms)
            {
                model.Rooms.Add(room);
            }

            BookingVm = model;
        }
    }
}
