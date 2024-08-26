using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Dapper;
using HotelSystem.Models;

namespace HotelSystem.Data.DataAccess
{
    public class CustomerDapper
    {
        private readonly string _connectionString;

        public CustomerDapper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AlexDbConnection"].ConnectionString;
        }

        public IEnumerable<HotelSystem.Models.Customers> GetAllCustomers()

        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "EXEC Customers_GetDataAll";
                var data = db.Query<HotelSystem.Models.Customers>(sqlQuery); 
                return data;
            }
        }

        public HotelSystem.Models.Customers GetCustomer(int Id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "EXEC Customers_GetData @Id";
                var data = db.Query<HotelSystem.Models.Customers>(sqlQuery, new
                {
                    Id = Id
                }).FirstOrDefault(); 
                return data;
            }
        }

        public bool Update(Models.Customers data)
        {
            var formattedDate = data.DateOfBirth.ToString("yyyy-MM-dd");

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    string sqlQuery = "EXEC Customers_Update @Id, @FirstName, @LastName, @Email, @PhoneNumber, @Address, @DateOfBirth, @Note";
                    db.Execute(sqlQuery, new
                    {
                        Id = data.Id,
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                        Email = data.Email,
                        PhoneNumber = data.PhoneNumber,
                        Address = data.Address,
                        DateOfBirth = formattedDate,
                        Note = data.Note,
                    });

                    return true;

                } catch (Exception ex)
                {
                  return false;
                }
            }
        }

        public bool Insert(Models.Customers data)
        {
            var formattedDate = data.DateOfBirth.ToString("yyyy-MM-dd");

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
               try
                {
                    string sqlQuery = "EXEC Customers_Insert @FirstName, @LastName, @Email, @PhoneNumber, @Address, @DateOfBirth, @Note";
                    db.Execute(sqlQuery, new
                    {
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                        Email = data.Email,
                        PhoneNumber = data.PhoneNumber,
                        Address = data.Address,
                        DateOfBirth = formattedDate,
                        Note = data.Note,
                    });
                    return true;

                } 
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Delete(int Id) 
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    string sqlQuery = "EXEC Customers_Delete @Id";
                    db.Execute(sqlQuery, new
                    {
                        Id = Id,
                    });

                    return true;
                } 
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
    }
}