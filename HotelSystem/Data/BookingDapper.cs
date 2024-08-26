using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace HotelSystem.Data.DataAccess
{
    public class BookingDapper
    {
        private readonly string _connectionString;

        public BookingDapper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AlexDbConnection"].ConnectionString;
        }

        public IEnumerable<HotelSystem.Models.Booking> GetAllBooking()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "EXEC Booking_GetDataAll";
                var data = db.Query<HotelSystem.Models.Booking>(sqlQuery); 
                return data;
            }
        }

        public Models.Booking GetBooking(int Id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "EXEC Booking_GetData @Id";
                var data = db.Query<HotelSystem.Models.Booking>(sqlQuery, new
                {
                    Id = Id
                }).FirstOrDefault();
                return data;
            }
        }


        public bool Update(Models.Booking data)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {                
                try
                {
                    string sqlQuery = "EXEC Booking_Update @RoomId, @CustomerId, @CheckInDate, @CheckOutDate, @Note";
                    db.Execute(sqlQuery, new
                    {
                        RoomId = data.RoomId,
                        CustomerId = data.CustomerId,
                        CheckInDate = data.CheckInDate,
                        CheckOutDate = data.CheckOutDate,
                        //TotalAmount = data.TotalAmount,
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

        public bool Insert(Models.Booking data)
        {
            //var formattedDate = data.DateOfBirth.ToString("yyyy-MM-dd");

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    string sqlQuery = "EXEC Booking_Insert @RoomId, @CustomerId, @CheckInDate, @CheckOutDate, @Note";
                    db.Execute(sqlQuery, new
                    {
                        RoomId = data.RoomId,
                        CustomerId = data.CustomerId,
                        CheckInDate = data.CheckInDate,
                        CheckOutDate = data.CheckOutDate,
                        //TotalAmount = data.TotalAmount,
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
                    string sqlQuery = "EXEC Booking_Delete @Id";
                    db.Execute(sqlQuery, new
                    {
                        Id = Id,
                    });

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}