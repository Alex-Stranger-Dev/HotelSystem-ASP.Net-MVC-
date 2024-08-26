using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelSystem.Data.DataAccess;
using Microsoft.Ajax.Utilities;


namespace HotelSystem.Managers
{
    public class ManagerBooking
    {
        private readonly BookingDapper _bookingDapper;

        public ManagerBooking()
        {
            _bookingDapper = new BookingDapper();
        }

        
        public IEnumerable<Models.Booking> GetAllBooking() 
        {
            var booking = _bookingDapper.GetAllBooking(); 
            return booking;
        }

        public Models.Booking GetBooking(int Id)
        {
            var booking = _bookingDapper.GetBooking(Id);
            return booking;
        }

        public bool Update(Models.Booking booking)
        {
            var result = _bookingDapper.Update(booking);
            return result;
        }

        public bool Delete(int Id)
        {
            var result = _bookingDapper.Delete(Id);
            return result;
        }

        public bool Insert(Models.Booking booking)
        {
            var result = _bookingDapper.Insert(booking);
            return result;
        }
    }
}

