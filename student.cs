using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Examination_System
{
    public partial class student : Form
    {
        public student()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            string select = "select * from Student";
            DataTable dataTable = new DataTable();
            sqlCommand.CommandText = select;
            SqlDataReader dreader;
            sqlConnection1.Open();
            dreader = sqlCommand.ExecuteReader();
            dataTable.Load(dreader);
            dataGridView1.DataSource = dataTable;
            dreader.Close();
            sqlConnection1.Close();
            txtStudentID.ReadOnly = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void Admin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;

        private void Admin_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

       
        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            sqlConnection1.Open();
            SqlCommand sqlc = new SqlCommand("insertStudent",sqlConnection1);
            sqlc.CommandType = CommandType.StoredProcedure;
            sqlc.Parameters.AddWithValue("@fname", txtStudentFName.Text);
            sqlc.Parameters.AddWithValue("@lname", txtStudentLName.Text);
            sqlc.Parameters.AddWithValue("@age", txtStudentAge.Text);
            sqlc.Parameters.AddWithValue("@address", txtStudentAdd.Text);

            if (txtDeptID.Text != "") {
                sqlc.Parameters.AddWithValue("@deptid", int.Parse(txtDeptID.Text)); }
            sqlc.ExecuteNonQuery();
            sqlConnection1.Close() ;
            txtStudentID.Text = txtStudentFName.Text = txtStudentLName.Text = txtStudentAge.Text = txtStudentAdd.Text = txtStudentAdd.Text = txtDeptID.Text= string.Empty;
            string select = "select * from Student";
            DataTable dataTable = new DataTable();
            sqlCommand.CommandText = select;
            SqlDataReader dreader;
            sqlConnection1.Open();
            dreader = sqlCommand.ExecuteReader();
            dataTable.Load(dreader);
            dataGridView1.DataSource = dataTable;
            dreader.Close();
            sqlConnection1.Close();
            MessageBox.Show("Added Successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            SqlCommand sqlc = new SqlCommand("updateStudent", sqlConnection1);
            sqlc.CommandType = CommandType.StoredProcedure;
            sqlc.Parameters.AddWithValue("@id", int.Parse(txtStudentID.Text));
            sqlc.Parameters.AddWithValue("@fname", txtStudentFName.Text);
            sqlc.Parameters.AddWithValue("@lname", txtStudentLName.Text);
            sqlc.Parameters.AddWithValue("@age", txtStudentAge.Text);
            sqlc.Parameters.AddWithValue("@address", txtStudentAdd.Text);
            sqlc.Parameters.AddWithValue("@deptid", int.Parse(txtDeptID.Text));
            sqlc.ExecuteNonQuery();
            sqlConnection1.Close();
            txtStudentID.Text = txtStudentFName.Text = txtStudentLName.Text = txtStudentAge.Text = txtStudentAdd.Text = txtStudentAdd.Text = txtDeptID.Text = string.Empty;
            string select = "select * from Student";
            DataTable dataTable = new DataTable();
            sqlCommand.CommandText = select;
            SqlDataReader dreader;
            sqlConnection1.Open();
            dreader = sqlCommand.ExecuteReader();
            dataTable.Load(dreader);
            dataGridView1.DataSource = dataTable;
            dreader.Close();
            sqlConnection1.Close();
            MessageBox.Show("Edited Successfully");
            txtStudentID.ReadOnly = false;


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string mykeyword = txtSearch.Text;
            DataTable data = new DataTable();
            SqlDataReader dr;
            sqlConnection1.Open();
            SqlCommand sqlc = new SqlCommand("searchStudent", sqlConnection1);
            sqlc.CommandType = CommandType.StoredProcedure;
            sqlc.Parameters.AddWithValue("@text", mykeyword);
            data.Load(sqlc.ExecuteReader());
            dataGridView1.DataSource = data;
            sqlConnection1.Close();
            


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentID.Text = txtStudentFName.Text = txtStudentLName.Text = txtStudentAge.Text = txtStudentAdd.Text = txtStudentAdd.Text = txtDeptID.Text = txtSearch.Text= string.Empty;
         
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtStudentID.ReadOnly = true;
            txtStudentID.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            txtStudentFName.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            txtStudentLName.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            txtStudentAge.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            txtStudentAdd.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            txtDeptID.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selected = Convert.ToInt32(txtStudentID.Text);
            sqlConnection1.Open();
            SqlCommand sqlc = new SqlCommand("deleteStudent", sqlConnection1);
            sqlc.CommandType = CommandType.StoredProcedure;
            sqlc.Parameters.AddWithValue("@id", selected);
             sqlc.ExecuteNonQuery();
            sqlConnection1.Close();
            txtStudentID.Text = txtStudentFName.Text = txtStudentLName.Text = txtStudentAge.Text = txtStudentAdd.Text = txtStudentAdd.Text = txtDeptID.Text = string.Empty;
            string select = "select * from Student";
            DataTable dataTable = new DataTable();
            sqlCommand.CommandText = select;
            SqlDataReader dreader;
            sqlConnection1.Open();
            dreader = sqlCommand.ExecuteReader();
            dataTable.Load(dreader);
            dataGridView1.DataSource = dataTable;
            dreader.Close();
            sqlConnection1.Close();
            MessageBox.Show("Deleted Successfully");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new dashboard().Show();
            this.Hide();
        }
    }
}
