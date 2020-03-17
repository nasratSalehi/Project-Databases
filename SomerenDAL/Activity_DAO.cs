using System;
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
    public class Activity_DAO : Base
    {
        // Excecutes SQL query for the Room table. 
        public List<Activity> Db_Get_All_Activities()
        {
            string query = "SELECT Id, description, number_of_students, number_of_supervisors FROM Activity";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // Attaches query data to object properties.  
        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity()
                {
                    Number = (int)dr["Id"],
                    Description = (string)(dr["description"]),
                    Number_of_students = (int)(dr["number_of_students"]),
                    Number_of_supervisors = (int)(dr["number_of_supervisors"])
                };
                activities.Add(activity);
            }
            return activities;
        }
    }
}
