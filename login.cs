using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System
{

    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

         public List<int> ids = new List<int>();
        public int[] userids;

        private void Form1_Load(object sender, EventArgs e)
        {
            string select = "select Sid,Lname from Student";
            sqlCommand1.CommandText = select;
            SqlDataReader dreader; 
            sqlConnection1.Open();
            dreader = sqlCommand1.ExecuteReader();
            while (dreader.Read())
            {
                ids.Add((int)dreader[0]);
                userids = ids.ToArray();

            }
            dreader.Close();
            sqlConnection1.Close();
            

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "admin" && txtPassword.Text=="admin")
            {
                new dashboard().Show();
                this.Hide();
            }
            else
            {
                for (int i = 0; i < userids.Length; i++)
                {
                    if(txtUserName.Text==userids[i].ToString() && txtPassword.Text == "iti41")
                    {
                        new studentExams().Show();
                       
                    }

                }
                MessageBox.Show("your username or password is incorrect", "Authentaction error");

                txtPassword.Clear();
                txtUserName.Clear();
                txtUserName.Focus();


            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            lastPoint = new Point(e.X, e.Y);
        }
    }
}
