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
    public partial class Kas : Form
    {
        factoryMethod ff = new factoryMethod();
        int odemeid;
        MySqlConnection connection = new MySqlConnection("datasource =localhost;Database=dershane;port=33010;username=root;password=12345;");

       // public odemee K { get; set; } = ff.odemeFactory("kas");

        public Kas()
        {
            InitializeComponent();
            Gridfill(); 
        }
        public void clear()
        {
            textBox1.Text = "";
            textBox3.Text = "";
            odemeid = 0;
            button1.Text = "ekle";
            button3.Enabled = false;
        }

        void Gridfill()
        {
            using (connection)
            {

                MySqlDataAdapter sqlda = new MySqlDataAdapter("odemeviewall", connection);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbodeme = new DataTable();
                sqlda.Fill(dtbodeme);
                dataGridView1.DataSource = dtbodeme;
                dataGridView1.Columns[0].Visible = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (connection)
            {
               
                connection.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("odemeaddoredit", connection);
                mysqlcmd.CommandType = CommandType.StoredProcedure;
                mysqlcmd.Parameters.AddWithValue("_idodeme", odemeid);
               // mysqlcmd.Parameters.AddWithValue("_miktar", K.getUcret());
                mysqlcmd.Parameters.AddWithValue("_tarih", textBox3.Text.Trim());
                mysqlcmd.Parameters.AddWithValue("_idogrenci", textBox1.Text.Trim());
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
                MySqlCommand mysqlcmd = new MySqlCommand("odemedeletebyid", connection);
                mysqlcmd.CommandType = CommandType.StoredProcedure;
                mysqlcmd.Parameters.AddWithValue("_idodeme", odemeid);
                mysqlcmd.ExecuteNonQuery();
                MessageBox.Show("Başariyla silindi");
                clear();
                Gridfill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Kas = new Odeme();
            Kas.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                connection.Open();
                MySqlDataAdapter sqlda = new MySqlDataAdapter("odemesearchbyvalue", connection);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.AddWithValue("_searchvalue", textBox5.Text);
                DataTable dtbodeme = new DataTable();
                sqlda.Fill(dtbodeme);
                dataGridView1.DataSource = dtbodeme;
                dataGridView1.Columns[0].Visible = false;

            }
        }

        private void Kas_Load(object sender, EventArgs e)
        {
            clear();
            Gridfill();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {

                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
              
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                odemeid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                button1.Text = "Update";
                button3.Enabled = Enabled;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
