using HotelSystem.Data.DataAccess;
using HotelSystem.Managers;
using HotelSystem.Rooms;
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
            
            var customers = new CustomersController().Index() as ViewResult;
            ViewBag.Customers = customers.Model;

            
            var rooms = new RoomsController().Index() as ViewResult;
            ViewBag.Rooms = rooms.Model;
            return View(booking);
        }

        [HttpPost]
        public ActionResult Update(Models.Booking booking)
        {
            bool result = _manager.Update(booking);
            if (result)
            {
                return Json(new { success = true, message = "Data is updated", reloadPage = true });
            }
            else
            {
                return Json(new { success = false, message = "Something went wrong", redirectUrl = Url.Action("Index", "Booking") });
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
            var customers = new CustomersController().Index() as ViewResult;
            ViewBag.Customers = customers.Model;

            var rooms = new RoomsController().Index() as ViewResult;
            ViewBag.Rooms = rooms.Model;

            return View();
        }

        [HttpPost]
        public ActionResult Insert(Models.Booking booking)
        {
            bool result = _manager.Insert(booking);
            if (result)
            {
                return Json(new { success = true, message = "Data is added", reloadPage = true });
            }
            else
            {
                return Json(new { success = false, message = "Something went wrong" });
            }

        }
    }

}