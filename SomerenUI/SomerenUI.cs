using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if(panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if(panelName == "Students")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                lbl_checkedview.Text = "Students";

                // show students
                pnl_Students.Show();

                

                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                // clear the listview before filling it again
                listView.Clear();
                listView.Columns.Add("ID", 30);
                listView.Columns.Add("Name", 100);
                listView.Columns.Add("DayOfBirth", 200);

                foreach (SomerenModel.Student student in studentList)
                {

                   
                    ListViewItem li = new ListViewItem(student.Number.ToString());
                    li.Tag = student;
                    li.SubItems.Add(student.Name);
                    li.SubItems.Add(student.BirthDate.ToString("dd/mm/yyyy"));
                    listView.Items.Add(li);
                }
            }
            else if (panelName == "Lecturers")
            {
                //hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();

                //show students
                pnl_Students.Show();
                lbl_checkedview.Text = "Lecturers";


               // fill the students listview within the students panel with a list of students
                SomerenLogic.Teacher_Service TeacherService = new SomerenLogic.Teacher_Service();
                List<Teacher> teacherList = TeacherService.GetTeachers();

                //clear the listview before filling it again
                listView.Clear();
                listView.Columns.Add("ID", 30);
                listView.Columns.Add("Name", 100);
                //listView.Columns.Add("DayOfBirth", 200);
                foreach (SomerenModel.Teacher t in teacherList)
                {

                    ListViewItem li = new ListViewItem(t.Number.ToString());
                    li.SubItems.Add(t.Name);
                    listView.Items.Add(li);
                }
            }
            else if (panelName == "Room")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();

                //show students
                pnl_Students.Show();
                lbl_checkedview.Text = "Room";


                //fill the students listview within the students panel with a list of students
                SomerenLogic.Room_Service RoomService = new SomerenLogic.Room_Service();
                List<Room> roomList = RoomService.GetRooms();


                //clear the listview before filling it again
                listView.Clear();
                // Add columns
                listView.Columns.Add("Number", 30);
                listView.Columns.Add("Capacity", 40);
                listView.Columns.Add("Type", 200);

                foreach (SomerenModel.Room r in roomList)
                {

                    ListViewItem li = new ListViewItem(r.Number.ToString());
                    li.SubItems.Add(r.Capacity.ToString());
                    if(r.Type == true)
                    {
                        li.SubItems.Add("Teacher");
                    }
                    else
                    {
                        li.SubItems.Add("Student");
                    }
                    listView.Items.Add(li);
                   
                }

            }
        }

            private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Lecturers");
        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

            showPanel("Lecturers");
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Room");
        }

    }
}
