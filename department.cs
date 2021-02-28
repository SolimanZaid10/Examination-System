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
    public partial class department : Form
    {
        public department()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new dashboard().Show();
            this.Hide();
        }

        private void department_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;

        private void department_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void department_Load(object sender, EventArgs e)
        {
            string select = "select * from Department";
            DataTable dataTable = new DataTable();
            sqlCommand1.CommandText = select;
            SqlDataReader dreader;
            sqlConnection1.Open();
            dreader = sqlCommand1.ExecuteReader();
            dataTable.Load(dreader);
            dataGridView1.DataSource = dataTable;
            dreader.Close();
            sqlConnection1.Close();
            txtDeptId.ReadOnly = true;
           

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        private void txtSearchDept_TextChanged(object sender, EventArgs e)
        {
            string mykeyword = txtSearchDept.Text;
            DataTable data = new DataTable();
            SqlDataReader dr;
            sqlConnection1.Open();
            SqlCommand sqlc = new SqlCommand("searchDepartment", sqlConnection1);
            sqlc.CommandType = CommandType.StoredProcedure;
            sqlc.Parameters.AddWithValue("@text", mykeyword);
            data.Load(sqlc.ExecuteReader());
            dataGridView1.DataSource = data;
            sqlConnection1.Close();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtDeptId.Text= dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            txtDeptName.Text= dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            txtMngerID.Text= dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDeptName.Text = txtMngerID.Text = txtDeptId.Text=string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selected = Convert.ToInt32(txtDeptId.Text);
            sqlConnection1.Open();
            SqlCommand sqlc = new SqlCommand("deleteDepartment", sqlConnection1);
            sqlc.CommandType = CommandType.StoredProcedure;
            sqlc.Parameters.AddWithValue("@id", selected);
            sqlc.ExecuteNonQuery();
            sqlConnection1.Close();
            txtDeptName.Text = txtMngerID.Text = txtDeptId.Text = string.Empty;
            string select = "select * from Department";
            DataTable dataTable = new DataTable();
            sqlCommand1.CommandText = select;
            SqlDataReader dreader;
            sqlConnection1.Open();
            dreader = sqlCommand1.ExecuteReader();
            dataTable.Load(dreader);
            dataGridView1.DataSource = dataTable;
            dreader.Close();
            sqlConnection1.Close();
            MessageBox.Show("Deleted Successfully");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
