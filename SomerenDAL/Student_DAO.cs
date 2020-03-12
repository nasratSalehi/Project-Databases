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
    public class Student_DAO : Base
    {
        // Excecutes SQL query for the Student table. 
        public List<Student> Db_Get_All_Students()
        {
            string query = "SELECT student_id, student_name, birthDate FROM Student";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // Attaches query data to object properties.  
        private List<Student> ReadTables(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student()
                {
                    Number = (int)dr["student_id"],
                    Name = (String)(dr["student_name"].ToString())
                };
                students.Add(student);
            }
            return students;
        }

    }
}
