using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace HotelSystem.Data.DataAccess
{
    public class RoomsDapper
    {
        private readonly string _connectionString;

        public RoomsDapper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AlexDbConnection"].ConnectionString;
        }

        public IEnumerable<HotelSystem.Models.Rooms> GetAllRooms()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "EXEC Rooms_GetDataAll";
                var data = db.Query<HotelSystem.Models.Rooms>(sqlQuery); 
                return data;
            }
        }

        public HotelSystem.Models.Rooms GetRoom(int Id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = "EXEC Rooms_GetData @Id";
                var data = db.Query<HotelSystem.Models.Rooms>(sqlQuery, new
                {
                    Id = Id
                }).FirstOrDefault();
                return data;
            }
        }

        public bool RoomsUpdate(Models.Rooms data)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    string sqlQuery = "EXEC Rooms_Update @Id, @RoomNumber, @RoomType, @PricePerNigth, @Status, @Note";
                   
                    db.Execute(sqlQuery, new
                    {
                        Id = data.Id,
                        RoomNumber = data.RoomNumber,
                        RoomType = data.RoomType,
                        PricePerNigth = data.PricePerNigth,
                        Status = data.Status,
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

        public bool Insert(Models.Rooms data)
        {
            //var formattedDate = data.DateOfBirth.ToString("yyyy-MM-dd");

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    string sqlQuery = "EXEC Rooms_Insert @RoomNumber, @RoomType, @PricePerNigth, @Status, @Note";
                    db.Execute(sqlQuery, new
                    {
                        RoomNumber = data.RoomNumber,
                        RoomType = data.RoomType,
                        PricePerNigth = data.PricePerNigth,
                        Status = data.Status,
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
                    string sqlQuery = "EXEC Rooms_Delete @Id";
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