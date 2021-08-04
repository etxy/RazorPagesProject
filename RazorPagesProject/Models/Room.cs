using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesProject.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }
        public string RoomSize { get; set; }

    }
}
