using HotelSystem.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelSystem.Rooms
{
    public class RoomsController : Controller
    {
        private readonly Managers.ManagerRooms manager;

        public RoomsController()
        {
            manager = new Managers.ManagerRooms();
        }

        // GET: Workers
        public ActionResult Index()
        {
           
            var rooms = manager.GetAllRooms(); 
            return View(rooms);
        }

        public ActionResult Details(int Id)
        {
            var rooms = manager.GetRoom(Id);
            return View(rooms);
        }

        [HttpPost]
        public ActionResult Update(Models.Rooms rooms)
        {
            bool result = manager.Update(rooms);
            if (result)
            {
                return Json(new { success = true, message = "Data is updated", reloadPage = true });
            }
            else
            {
                return Json(new { success = false, message = "Something went wrong", redirectUrl = Url.Action("Index", "Rooms") });
            }
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            bool result = manager.Delete(Id);
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
        public ActionResult Insert(Models.Rooms rooms)
        {
            bool result = manager.Insert(rooms);
            if (result)
            {
                return Json(new { success = true, message = "Data is added", reloadPage = true });
            }
            else
            {
                return Json(new { success = false, message = "Something went wrong", redirectUrl = Url.Action("Index", "Rooms") });
            }

        }
    }
}
