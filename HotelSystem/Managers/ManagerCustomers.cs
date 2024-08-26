using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelSystem.Data.DataAccess;
using Microsoft.Ajax.Utilities;


namespace HotelSystem.Managers
{
    public class ManagerCustomers
    {
        private readonly CustomerDapper _customerDapper;

        public ManagerCustomers()
        {
            _customerDapper = new CustomerDapper();
        }

        
        public IEnumerable<Models.Customers> GetAllCustomers() 
        {
            var customers = _customerDapper.GetAllCustomers(); //F11 ili Go To Implementation
            return customers;
        }

        public Models.Customers GetCustomer(int Id)
        {
            var customer = _customerDapper.GetCustomer(Id);
            return customer;
        }

        public bool Update(Models.Customers customer)
        {
            var result = _customerDapper.Update(customer);
            return result;  
        }

        public bool Delete(int Id)
        {
            var result = _customerDapper.Delete(Id);
            return result;
        }

        public bool Insert(Models.Customers customer)
        {
            var result = _customerDapper.Insert(customer);
            return result;
        }
    }
}

