using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesProject.Data;
using RazorPagesProject.Models;

namespace RazorPagesProject.Pages.Bookings
{
    public class BookingReportModel : PageModel
    {
        private readonly RazorPagesProject.Data.RazorPagesProjectContext _context;

        public BookingReportModel(RazorPagesProject.Data.RazorPagesProjectContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get; set; }
        public float TotalSales { get; set; }

        [BindProperty]
        public string BookingSearchString { get; set; }

        public async Task OnPostAsync()
        {
            var bookings = from r in _context.Booking
                           select r;
            if (!string.IsNullOrEmpty(BookingSearchString))
            { 
                TotalSales = (from r in _context.Booking
                         where r.Room.RoomName.Contains(BookingSearchString)
                         select r.TotalPrice).Sum();
            }
            Booking = await bookings.ToListAsync();
        }

    }
}
