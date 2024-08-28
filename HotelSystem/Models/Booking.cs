using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime CheckInDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime CheckOutDate { get; set; }
        public float TotalAmount { get; set; }
        public string Note { get; set; }
    }
}