using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Activity_Service
    {
        Activity_DAO activity_db = new Activity_DAO();

        public List<Activity> GetActivities()
        {
            try
            {
                List<Activity> activity = activity_db.Db_Get_All_Activities();
                return activity;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Activity> activities = new List<Activity>();
                Activity a = new Activity();
                a.Number = 101;
                a.Description = "Een hele leuke activiteit!";
                a.Number_of_students = 10;
                a.Number_of_supervisors = 2;
                activities.Add(a);
                return activities;
                throw new Exception("Someren couldn't connect to the database");
            }

        }
    }
}
