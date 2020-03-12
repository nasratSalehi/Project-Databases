using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Room_Service
    {
        Room_DAO room_db = new Room_DAO();

        public List<Room> GetRooms()
        {
            try
            {
                List<Room> room = room_db.Db_Get_All_Rooms();
                return room;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Room> rooms = new List<Room>();
                Room r = new Room();
                r.Number = 201;
                r.Capacity = 3;
                r.Type = true;
                rooms.Add(r);
                return rooms;
                throw new Exception("Someren couldn't connect to the database");
            }

        }
    }
}
