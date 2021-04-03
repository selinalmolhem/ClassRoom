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

    public partial class Kurs : Form
    {
        int kursid;
        MySqlConnection connection = new MySqlConnection("datasource =localhost;Database=dershane;port=33010;username=root;password=12345;");
        public Kurs()
        {
            InitializeComponent();
            Gridfill();
        }
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
           
            kursid = 0;
            button1.Text = "ekle";
            button3.Enabled = false;
        }
        void Gridfill()
        {
            using (connection)
            {


                MySqlDataAdapter sqlda = new MySqlDataAdapter("kursviewall", connection);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbogrenci = new DataTable();
                sqlda.Fill(dtbogrenci);
                dataGridView1.DataSource = dtbogrenci;
                dataGridView1.Columns[0].Visible = false;

            }


        }
        private void Kurs_Load(object sender, EventArgs e)
        {
            Gridfill();
            clear();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
        
            connection.Open();
            using (connection)
            {
                
                connection.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("kursaddoredit", connection);
                mysqlcmd.CommandType = CommandType.StoredProcedure;
                mysqlcmd.Parameters.AddWithValue("_idkurs", kursid);
                mysqlcmd.Parameters.AddWithValue("_ad", textBox1.Text.Trim());
                mysqlcmd.Parameters.AddWithValue("_idhoca", textBox3.Text.Trim());
                mysqlcmd.Parameters.AddWithValue("_tarih", textBox2.Text.Trim());
                mysqlcmd.ExecuteNonQuery();//verileri veritabanda kayıt ediyoruz
                MessageBox.Show("submitted successfuly");
            }
            //  string insertQuery= "İNSERT INTO odeme.dershane(idodeme,miktar,idogrenci,tarih)"
            // MySqlCommand command = new MySqlCommand(insertQuery,connection);
            Gridfill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                connection.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("kursdeletebyid", connection);
                mysqlcmd.CommandType = CommandType.StoredProcedure;
                mysqlcmd.Parameters.AddWithValue("_idogrenci", kursid);
                mysqlcmd.ExecuteNonQuery();
                MessageBox.Show("Başariyla silindi");
                clear();
                Gridfill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
            Form Kurs = new Form1();
            Kurs.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                connection.Open();


                MySqlDataAdapter sqlda = new MySqlDataAdapter("kurssearchbyvalue", connection);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.AddWithValue("_searchvalue", textBox4.Text);

                DataTable dtbogrenci = new DataTable();
                sqlda.Fill(dtbogrenci);
                dataGridView1.DataSource = dtbogrenci;
                dataGridView1.Columns[0].Visible = false;

            }
        }

     
        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {

                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                kursid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                button1.Text = "Update";
                button3.Enabled = Enabled;
            }
        }
    }
}
