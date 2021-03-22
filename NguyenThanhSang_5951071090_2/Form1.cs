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

namespace NguyenThanhSang_5951071090_2
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            GetStudentsRecord();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudentsRecord();
        }
        private void GetStudentsRecord()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-34K3251;Initial Catalog=DemoCRUD2;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentsTb", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            StudentRecordData.DataSource = dt;
        }
        private bool IsValidData()
        {
            if (txtHName.Text == string.Empty
               || txtTName.Text == string.Empty
               || txtAddress.Text == string.Empty
               || string.IsNullOrEmpty(txtPhone.Text)
               || string.IsNullOrEmpty(txtRoll.Text))
            {
                MessageBox.Show("Có chỗ chưa nhập dử liệu !!!", "Lỗi dử liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-34K3251;Initial Catalog=DemoCRUD2;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("INSERT INTO StudentsTb VALUES" + "(@Name, @FatherName,@RollNumber,@Address,@Mobile)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtHName.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtTName.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txtRoll.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtPhone.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentsRecord();
            }
        }

        public int StudenID;
        private void StudentRecordData_CellCClick(object sender, DataGridViewCellEventArgs e)
        {
            StudenID = Convert.ToInt32(StudentRecordData.Rows[0].Cells[0].Value);
            txtHName.Text = StudentRecordData.Rows[0].Cells[1].ToString();
            txtTName.Text = StudentRecordData.Rows[0].Cells[2].ToString();
            txtRoll.Text = StudentRecordData.Rows[0].Cells[3].ToString();
            txtAddress.Text = StudentRecordData.Rows[0].Cells[4].ToString();
            txtPhone.Text = StudentRecordData.Rows[0].Cells[5].ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (StudenID > 0)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-34K3251;Initial Catalog=DemoCRUD2;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("UPDATE StudentsTb SET" + "Name=@Name, FatherName=@FatherName," + "RollNumber = @RollNumber, Address = @Address," + "Mobile = @Mobile where StudentID=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtHName.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtTName.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txtRoll.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtPhone.Text);
                cmd.Parameters.AddWithValue("@ID", this.StudenID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentsRecord();
                ResetData();

            }
            else
            {
                MessageBox.Show("Cập nhật bị lỗi!!!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ResetData()
        {
            throw new NotImplementedException();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (StudenID > 0)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-34K3251;Initial Catalog=DemoCRUD2;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("DELETE FROM StudentsTb where StudentID=@ID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", this.StudenID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentsRecord();
                ResetData();

            }
            else
            {
                MessageBox.Show("Cập nhật bị lỗi!!!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRoll_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
