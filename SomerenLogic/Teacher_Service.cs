using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Teacher_Service
    {
        Teacher_DAO teacher_db = new Teacher_DAO();

        public List<Teacher> GetTeachers()
        {
            try
            {
                List<Teacher> teacher = teacher_db.Db_Get_All_Teachers();
                return teacher;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Teacher> teachers = new List<Teacher>();
                Teacher t = new Teacher();
                t.Name = "Mr. Stikker";
                t.Number = 474791;
                teachers.Add(t);
                return teachers;
                throw new Exception("Someren couldn't connect to the database");
            }

        }
    }
}
