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
                List<Room> room = new List<Room>();
                /*Student a = new Student();
                a.Name = "Mr. Test Student";
                a.Number = 474791;
                a.BirthDate = DateTime.Parse("1990-07-04");
                student.Add(a);
                Student b = new Student();
                b.Name = "Mrs. Test Student";
                b.Number = 197474;
                b.BirthDate = DateTime.Parse("2019-03-04");
                student.Add(b);*/
                return room;
                throw new Exception("Someren couldn't connect to the database");
            }

        }
    }
}
