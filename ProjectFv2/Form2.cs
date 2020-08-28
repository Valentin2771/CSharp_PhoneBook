using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;

namespace ProjectFv2
{
    public partial class FrmSearchWindow : Form
    {
        public FrmSearchWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string val = "";
            string field = "";

            if (radioButton1.Checked == true)
            {
                val = textBox1.Text;
                field = "Nume";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            
            if (radioButton2.Checked == true)
            {
                val = textBox2.Text;
                field = "Prenume";
                textBox1.Text = "";
                textBox3.Text = "";
            }
            
            if (radioButton3.Checked == true)
            {
                val = textBox3.Text;
                field = "Telefon";
                textBox2.Text = "";
                textBox1.Text = "";
            }
            
            try
            {
                dataGridView1.DataSource = (new Abonati()).SelectParametrizat(field, val);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
