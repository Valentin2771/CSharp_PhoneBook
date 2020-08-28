using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using BAL;

namespace ProjectFv2
{
    public partial class FrmMainWindow : Form
    {
        Abonati abonati = new Abonati();
        bool sw;

        public FrmMainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            DataGridViewColumn dcID = new DataGridViewTextBoxColumn();
            dcID.Name = "ID";
            dcID.HeaderText = "ID";
            dataGridView1.Columns.Add(dcID);

            DataGridViewColumn dcNume = new DataGridViewTextBoxColumn();
            dcNume.Name = "Nume";
            dcNume.HeaderText = "Nume";
            dataGridView1.Columns.Add(dcNume);

            DataGridViewColumn dcPrenume = new DataGridViewTextBoxColumn();
            dcPrenume.Name = "Prenume";
            dcPrenume.HeaderText = "Prenume";
            dataGridView1.Columns.Add(dcPrenume);

            DataGridViewColumn dcTelefon = new DataGridViewTextBoxColumn();
            dcTelefon.Name = "Telefon";
            dcTelefon.HeaderText = "Telefon";
            dataGridView1.Columns.Add(dcTelefon);

            try
            {
                List<Abonati> lista2 = abonati.Select();

                foreach (Abonati ab in lista2)
                {
                    DataGridViewRow dr = dataGridView1.Rows[dataGridView1.Rows.Add()];

                    dr.Cells["ID"].Value = ab.AccessId;
                    dr.Cells["Nume"].Value = ab.AccessNume;
                    dr.Cells["Prenume"].Value = ab.AccessPrenume;
                    dr.Cells["Telefon"].Value = ab.AccessTelefon;

                }
            }
            catch (Exception exp2)
            {
                MessageBox.Show(exp2.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sw = true;
            dataGridView1.ReadOnly = true;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(sw)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.ReadOnly = false;
                sw = false;
            }
            else
            {
                dataGridView1.DataSource = null;
            }

            button2.Enabled = true;

            try 
            {
                dataGridView1.DataSource = abonati.Select2();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                abonati.Update((DataTable)dataGridView1.DataSource);
                MessageBox.Show("Data saved successfully", "", MessageBoxButtons.OK);
            }

            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // handler pentru situatia in care se incearca initializarea cheii primare cu alte valori decat int

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error: " + e.ToString() + "\nPrimay key is of type int and shouldn't be null!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // optiunea File->Serializare Informatii

        private void serializareInformatiiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Nimic de serializat. Numar linii: " + (dataGridView1.Rows.Count - 1), "", MessageBoxButtons.OK);
            }
            else
            {
                
                saveFileDialog1.Title = "Salvare fisier serializare";
                saveFileDialog1.Filter = "XML files | *.xml";
                saveFileDialog1.InitialDirectory = Application.StartupPath;
                saveFileDialog1.DefaultExt = "xml";
                saveFileDialog1.FileName = "Abonati_" + DateTime.Now.ToString("yyyymmddhhmmss");
                saveFileDialog1.ShowDialog();
            }
        }

        // optiunea File->Afisare Informatii; NEIMPLEMENTATA, conform proiectului

        private void afisareInformatiiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // optiunea File->Exit

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (6 == (int)MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNo))
            {
                Application.Exit();
            }
            
        }

        // handler pentru salvarea efectiva a fisierului xml

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            List<Abonati> listaAbonatiGrid = new List<Abonati>();
            int i = 0;

            while (i < dataGridView1.Rows.Count - 1)
            {
                Abonati abonat = new Abonati();
                abonat.AccessId = Convert.ToInt32(dataGridView1.Rows[i].Cells["ID"].Value);
                abonat.AccessNume = (Convert.ToString(dataGridView1.Rows[i].Cells["Nume"].Value)).Trim();
                abonat.AccessPrenume = (Convert.ToString(dataGridView1.Rows[i].Cells["Prenume"].Value)).Trim();
                abonat.AccessTelefon = (Convert.ToString(dataGridView1.Rows[i].Cells["Telefon"].Value)).Trim();
                ++i;
                listaAbonatiGrid.Add(abonat);
            }

            XmlSerializer sr = new XmlSerializer(typeof(List<Abonati>));

            using (Stream fStream = new FileStream("Abonati_" + DateTime.Now.ToString("yyyymmddhhmmss") + ".xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                sr.Serialize(fStream, listaAbonatiGrid);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        // Fereastra FrmSearchWindow este afisata la optiunea Edit->Cautare persoana. Existenta acestei ferestre este o cerinta explicita a proiectului insa detaliile implementarii nu sunt mentionate in specificatii

        private void cautaPersoanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmSearchWindow f2 = new FrmSearchWindow())
            {
                f2.ShowDialog();
            }
        }
    }
}
