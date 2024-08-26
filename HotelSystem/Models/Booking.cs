using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public float TotalAmount { get; set; }
        public string Note { get; set; }
    }
}