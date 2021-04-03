using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dershaneSON
{
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Odeme = new Kas();
            Odeme.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Odeme = new Taksitt();
            Odeme.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Odeme = new Form1();
            Odeme.Show();
            this.Hide();
        }
    }
}
