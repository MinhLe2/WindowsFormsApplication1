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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            
            ketnoicsdl();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-076VVOB;Initial Catalog=SV;Integrated Security=True");
        private void ketnoicsdl()
        {
            cnn.Open();
            string sql = "select * from sinhvien";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        void add()
        {
            string sex = null;
            if (radioButton1.Checked == true) sex = "Male";
            else if (radioButton2.Checked == true) sex = "Female";
            string Insertsql = "INSERT INTO SV( Name , Sex, FinalGrade, FinalDate, Rank , Achievements)values (@Name,@Sex,@Class,@FinalGrade,@FinalDate,@Rank,@Achievements)";
            SqlCommand mi = new SqlCommand(Insertsql,mi);
            mi.Parameters.AddWithValue("@Name", textBoxName.Text);
            mi.Parameters.AddWithValue("@Sex", sex);
            mi.Parameters.AddWithValue("@Class", textBoxClass.Text);
            mi.Parameters.AddWithValue("@FinalGrade", numericUpDown1.Text);
            mi.Parameters.AddWithValue("@FinalDate", dateTimePicker1.Text);
            mi.Parameters.AddWithValue("@Rank", comboBox1.Text);
            mi.Parameters.AddWithValue("@Achievements", listBox1.Text);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == string.Empty)
                MessageBox.Show("TextBox is Emty");
            if (textBoxClass.Text == string.Empty)
                MessageBox.Show("TextBox is Emty");
            if (radioButton1.Checked == false && radioButton2.Checked == false)
                MessageBox.Show("Choose 1 of them");
            if (numericUpDown1.Value < 0)
                MessageBox.Show("FinalGrade must be more than 0");
            if (dateTimePicker1.Value >= DateTime.Now)
                MessageBox.Show("FinalDate must be more than today");
            add();
        }
    }
}
