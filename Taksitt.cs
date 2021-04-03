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
    public partial class Taksitt : Form
    {
        factoryMethod ff = new factoryMethod();
       // odemee k = ff.odemeFactory("taksit");
        MySqlConnection connection = new MySqlConnection("datasource =localhost;Database=dershane;port=33010;username=root;password=12345;");
        int odemeid;
        public Taksitt()
        {
            InitializeComponent();
            Gridfill();
        }
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            odemeid = 0;
            button1.Text = "ekle";
            button3.Enabled = false;
        }

        void Gridfill()
        {
            using (connection)
            {

                MySqlDataAdapter sqlda = new MySqlDataAdapter("odemeviewall2", connection);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbodeme = new DataTable();
                sqlda.Fill(dtbodeme);
                dataGridView1.DataSource = dtbodeme;
                dataGridView1.Columns[0].Visible = false;

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form Taksitt = new Odeme();
            Taksitt.Show();
            this.Hide();
        }

        private void Taksitt_Load(object sender, EventArgs e)
        {
            clear();
            Gridfill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                connection.Open();
                MySqlCommand mysqlcmd = new MySqlCommand("odemeaddoredit", connection);
                mysqlcmd.CommandType = CommandType.StoredProcedure;
                mysqlcmd.Parameters.AddWithValue("_idodeme", odemeid);
            //    mysqlcmd.Parameters.AddWithValue("_miktar", k.getUcret());
              //  mysqlcmd.Parameters.AddWithValue("_tarih", k.getUcret());
                mysqlcmd.Parameters.AddWithValue("_btarih", textBox4.Text.Trim());
                mysqlcmd.Parameters.AddWithValue("_idogrenci", textBox2.Text.Trim());
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

        private void button4_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                connection.Open();
                MySqlDataAdapter sqlda = new MySqlDataAdapter("odemesearchbyvalue", connection);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.AddWithValue("_searchvalue", textBox4.Text);
                DataTable dtbodeme = new DataTable();
                sqlda.Fill(dtbodeme);
                dataGridView1.DataSource = dtbodeme;
                dataGridView1.Columns[0].Visible = false;

            }
        }

       

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {

                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                odemeid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                button1.Text = "Update";
                button3.Enabled = Enabled;

            }

        }
    }
}
