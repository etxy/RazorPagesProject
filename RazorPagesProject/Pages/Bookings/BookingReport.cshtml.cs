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
        public int Total { get; set; }
        public float Sales { get; set; }

        [BindProperty]
        public string BookingSearchString { get; set; }

        public async Task OnPostAsync()
        {
            var orders = from r in _context.Booking
                         select r;

            Booking = await orders.ToListAsync();
        }

    }
}
