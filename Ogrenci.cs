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
    public partial class Ogrenci : Form
    {
        waiters vv = new waiters();
        //Boolean bb = vv.printogrenci();
        Ogrenciii og;

        //  ogrencii ogrenci = new ogrencii();
        MySqlConnection connection = new MySqlConnection("datasource =localhost;Database=dershane;port=33010;username=root;password=12345;");
        public Ogrenci()
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
            textBox5.Text = "";
            ogrenciid = 0;
            button1.Text = "ekle";
            button3.Enabled = false;
        }
    void Gridfill()
    {
        using (connection)
        {


            MySqlDataAdapter sqlda = new MySqlDataAdapter("ogrenciviewall", connection);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbogrenci = new DataTable();
            sqlda.Fill(dtbogrenci);
            dataGridView2.DataSource = dtbogrenci;
            dataGridView2.Columns[0].Visible = false;

        }


    }
    int ogrenciid;
    private void Ogrenci_Load(object sender, EventArgs e)
        {
            clear();
            Gridfill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                
                connection.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("ogrenciaddoredit", connection);
                mysqlcmd.CommandType = CommandType.StoredProcedure;
                mysqlcmd.Parameters.AddWithValue("_idogrenci", ogrenciid);
                mysqlcmd.Parameters.AddWithValue("_tcogrenci", textBox5.Text.Trim());
                mysqlcmd.Parameters.AddWithValue("_sinif", textBox4.Text.Trim());
                mysqlcmd.Parameters.AddWithValue("_tel", og.GetOrtalama());
                mysqlcmd.Parameters.AddWithValue("_ad", textBox1.Text.Trim());
                mysqlcmd.Parameters.AddWithValue("_soyad", textBox2.Text.Trim());
                mysqlcmd.ExecuteNonQuery();
                MessageBox.Show("Başariyla eklendi");
                clear();
                Gridfill();
             //   if (bb == true)
            //    {
         //           string message = "burslu olarak eklendi";
         //           string title = "burs";
        //            MessageBox.Show(message, title);
       //         }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                connection.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("ogrencideletebyid", connection);
                mysqlcmd.CommandType = CommandType.StoredProcedure;
                mysqlcmd.Parameters.AddWithValue("_idogrenci", ogrenciid);
                mysqlcmd.ExecuteNonQuery();
                MessageBox.Show("Başariyla silindi");
                clear();
                Gridfill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
            Form Ogrenci = new Form1();
            Ogrenci.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                connection.Open();


                MySqlDataAdapter sqlda = new MySqlDataAdapter("ogrencisearchbyvalue", connection);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.AddWithValue("_searchvalue", textBox6.Text);

                DataTable dtbogrenci = new DataTable();
                sqlda.Fill(dtbogrenci);
                dataGridView2.DataSource = dtbogrenci;
                dataGridView2.Columns[0].Visible = false;

            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {

                textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                ogrenciid = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                button1.Text = "Update";
                button3.Enabled = Enabled;

            }
        }
    }
}
