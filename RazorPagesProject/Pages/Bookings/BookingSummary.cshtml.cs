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
    public class BookingSummaryModel : PageModel
    {
        private readonly RazorPagesProjectContext _context;

        // constructor - first entry
        public BookingSummaryModel(RazorPagesProjectContext context)
        {
            _context = context;
        }
        public Booking Booking { get; set; }
        public async Task OnGetAsync()
        {
            Booking = await _context.Booking.Include(x => x.Room).Include(x=>x.ServiceOptions)
                .OrderByDescending(i => i.ID).FirstOrDefaultAsync();
        }
    }
}
