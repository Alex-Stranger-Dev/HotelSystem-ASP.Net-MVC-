using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelSystem.Data.DataAccess;
using HotelSystem.Managers;
using Microsoft.Ajax.Utilities;

namespace HotelSystem.Controllers
{
    public class CustomersController : Controller
    {
        private readonly HotelSystem.Managers.ManagerCustomers manager;

        public CustomersController()
        {
            manager = new ManagerCustomers();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = manager.GetAllCustomers(); //F11 ili Go To Implementation
            return View(customers);
        }

        // GET: Customer

        public ActionResult Details(int Id) 
        {
            var customer = manager.GetCustomer(Id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Update(Models.Customers customer)
        {
            bool result = manager.Update(customer);
            if (result)
            {
                return Json(new{ success = true, message = "Data is updated" });
            }
            else
            {
                return Json(new { success = false, message = "Something went wrong" });
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
        public ActionResult Insert(Models.Customers customer)
        {
            bool result = manager.Insert(customer);
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