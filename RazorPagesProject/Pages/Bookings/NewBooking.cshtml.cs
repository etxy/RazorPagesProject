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
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RazorPagesProject.Pages.Bookings
{
    public class NewBookingModel : PageModel
    {
        private readonly RazorPagesProjectContext _context;
        public NewBookingModel(RazorPagesProjectContext context)
        {
            _context = context;
        }
        [BindProperty]
        public BookingVm BookingVm { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid) { }

            IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            Console.WriteLine(allErrors);

            //if (true)
            {
                var getFirstRoom = await _context.Room.FirstOrDefaultAsync(x => x.Id == BookingVm.BookingRoomId);

                if (BookingVm.Booking.CheckInDateTime > DateTime.Now.AddDays(60))
                {
                    BookingVm.Booking.TotalPrice = (float)Math.Round((BookingVm.Booking.TotalPrice * 0.9f), 2);
                    //BookingVm.  add a sentence to let customers know that they have a discount
                }

                var so = new List<ServiceOption>();

                foreach (var item in BookingVm.Booking.ServiceOptions)
                {
                    so.Add(item);
                }

                var booking = new Booking()
                {
                    CustomerName = BookingVm.Booking.CustomerName,
                    ContactNumber = BookingVm.Booking.ContactNumber,
                    CheckInDateTime = BookingVm.Booking.CheckInDateTime,
                    CheckOutDateTime = BookingVm.Booking.CheckInDateTime.AddDays(BookingVm.Booking.NumOfDays),
                    NumOfDays = BookingVm.Booking.NumOfDays,

                    Quantity = BookingVm.Booking.Quantity,
                    TotalPrice = BookingVm.Booking.TotalPrice,
                    Room = getFirstRoom,
                    ServiceOptions = so
                };

                _context.Booking.Add(booking);
                await _context.SaveChangesAsync();
                return Redirect("./BookingSummary");
            }
            return Redirect("~/");


        }
        public async Task OnGetAsync()
        {
            var rooms = await _context.Room.ToListAsync();
            var sos = await _context.ServiceOptions.ToListAsync();

            var model = new BookingVm();

            foreach (var room in rooms)
            {
                model.Rooms.Add(room);
            }

            foreach (var s in sos)
            {
                model.ServiceOptions.Add(s);
            }

            BookingVm = model;
        }
    }
}
