using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelSystem.Data.DataAccess;
using Microsoft.Ajax.Utilities;


namespace HotelSystem.Managers
{
    public class ManagerRooms
    {
        private readonly RoomsDapper _roomsDapper;

        public ManagerRooms()
        {
            _roomsDapper = new RoomsDapper();
        }

        
        public IEnumerable<Models.Rooms> GetAllRooms() 
        {
            var rooms = _roomsDapper.GetAllRooms(); 
            return rooms;
        }

        public Models.Rooms GetRoom(int Id)
        {
            var rooms = _roomsDapper.GetRoom(Id);
            return rooms;
        }

        public bool Update(Models.Rooms rooms)
        {
            var result = _roomsDapper.RoomsUpdate(rooms);
            return result;  
        }

        public bool Delete(int Id)
        {
            var result = _roomsDapper.Delete(Id);
            return result;
        }

        public bool Insert(Models.Rooms rooms)
        {
            var result = _roomsDapper.Insert(rooms);
            return result;
        }
    }
}

