using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace dershaneSON
{
    public partial class Hoca : Form
    {
        int hocaid;
        MySqlConnection connection = new MySqlConnection("datasource =localhost;Database=dershane;port=33010;username=root;password=12345;");
        public Hoca()
        {
            InitializeComponent();
            Gridfill();
        }
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            hocaid = 0;
            button1.Text = "ekle";
            button3.Enabled = false;
        }
        void Gridfill()
        {
            using (connection)
            {

                MySqlDataAdapter sqlda = new MySqlDataAdapter("hocaviewall", connection);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbhoca = new DataTable();
                sqlda.Fill(dtbhoca);
                dataGridView1.DataSource = dtbhoca;
                dataGridView1.Columns[0].Visible = false;

            }
        }

        private void Hoca_Load(object sender, EventArgs e)
        {
            clear();
            Gridfill();
        }

        private void dataGridView1_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                connection.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("hocaaddoredit", connection);
                mysqlcmd.CommandType = CommandType.StoredProcedure;
                mysqlcmd.Parameters.AddWithValue("_idhoca", hocaid);
                mysqlcmd.Parameters.AddWithValue("_tel", textBox3.Text.Trim());
                mysqlcmd.Parameters.AddWithValue("_ders", textBox4.Text.Trim());
                mysqlcmd.Parameters.AddWithValue("_ad", textBox1.Text.Trim());
                mysqlcmd.Parameters.AddWithValue("_soyad", textBox2.Text.Trim());
                mysqlcmd.ExecuteNonQuery();
                MessageBox.Show("Başariyla eklendi");
                clear();
                Gridfill();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                connection.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("hocadeletebyid", connection);
                mysqlcmd.CommandType = CommandType.StoredProcedure;
                mysqlcmd.Parameters.AddWithValue("_idhoca", hocaid);
                mysqlcmd.ExecuteNonQuery();
                MessageBox.Show("Başariyla silindi");
                clear();
                Gridfill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
            Form Hoca = new Form1();
            Hoca.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

     

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            using (connection)
            {
                connection.Open();
                MySqlDataAdapter sqlda = new MySqlDataAdapter("hocasearchbyvalue", connection);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.AddWithValue("_searchvalue", textBox5.Text);
                DataTable dtbhoca = new DataTable();
                sqlda.Fill(dtbhoca);
                dataGridView1.DataSource = dtbhoca;
                dataGridView1.Columns[0].Visible = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
