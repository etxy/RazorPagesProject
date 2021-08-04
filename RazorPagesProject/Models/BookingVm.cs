using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RazorPagesProject.Models
{
    public class BookingVm
    {
        public int BookingRoomId { get; set; }
        public bool BreakfastBuffet { get; set; }
        public bool Balcony { get; set; }
        public bool SeaView { get; set; }
        public bool ExtraBed { get; set; }

        public Booking Booking { get; set; }
        public IList<Room> Rooms { get; set; } = new List<Room>();

    }
}
