using HotelSystem.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSystem.Models
{
    public class Rooms
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        
        public TypeOfRooms RoomType { get; set; }

        public float PricePerNigth { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    }
}