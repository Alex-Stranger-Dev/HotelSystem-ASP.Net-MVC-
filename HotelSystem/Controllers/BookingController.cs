using HotelSystem.Data.DataAccess;
using HotelSystem.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly ManagerBooking _manager;

        public BookingController()
        {
            _manager = new ManagerBooking();
        }

        // GET: Workers
        public ActionResult Index()
        {
            
            var bookingList = _manager.GetAllBooking(); 
            return View(bookingList);
        }
        public ActionResult Details(int Id)
        {
            var booking = _manager.GetBooking(Id);
            return View(booking);
        }

        [HttpPost]
        public ActionResult Update(Models.Booking booking)
        {
            bool result = _manager.Update(booking);
            if (result)
            {
                return Json(new { success = true, message = "Data is updated" });
            }
            else
            {
                return Json(new { success = false, message = "Something went wrong" });
            }
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            bool result = _manager.Delete(Id);
            if (result)
            {
                return Json(new { success = true, message = "Data is deleted" });
            }
            else
            {
                return Json(new { success = false, message = "Something went wrong" });
            }

        }

        public ActionResult InsertForm()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Insert(Models.Booking booking)
        {
            bool result = _manager.Insert(booking);
            if (result)
            {
                return Json(new { success = true, message = "Data is added" });
            }
            else
            {
                return Json(new { success = false, message = "Something went wrong" });
            }

        }
    }

}