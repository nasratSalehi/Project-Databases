﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
    public class Room_DAO : Base
    {
        // Excecutes SQL query for the Room table. 
        public List<Room> Db_Get_All_Rooms()
        {
            string query = "SELECT roomId, capacity, type FROM Room";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // Attaches query data to object properties.  
        private List<Room> ReadTables(DataTable dataTable)
        {
            List<Room> rooms = new List<Room>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Room room = new Room()
                {
                    Number = (int)dr["roomid"],
                    Capacity = (int)(dr["capacity"]),
                    Type = (bool)(dr["type"]) 
                };
                rooms.Add(room);
            }
            return rooms;
        }

    }
}
