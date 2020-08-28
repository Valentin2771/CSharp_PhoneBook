using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;


namespace BAL
{
    public class Abonati
    {
        int ID;
        string Nume;
        string Prenume;
        string Telefon;

        DAbonati dab = new DAbonati();

        // constructor fara parametri; este folosit pentru crearea unui obiect a carui metoda va ajuta la instantierea campului corespunzator din FrmMainWindow
        public Abonati() { } 
    
        public Abonati(DataRow dr)
        {
            if (dr != null)
            {
                ID = (int)dr["ID"];
                Nume = (string)dr["Nume"];
                Prenume = (string)dr["Prenume"];
                Telefon = (string)dr["Telefon"];
            }
        }

        public int AccessId { get { return this.ID; } set { this.ID = value; } }
        public string AccessNume { get { return this.Nume; } set { this.Nume = value; } }
        public string AccessPrenume { get { return this.Prenume; } set { this.Prenume = value; } }
        public string AccessTelefon { get { return this.Telefon; } set { this.Telefon = value; } }

        public List<Abonati> Select()
        {
            DataTable dt = dab.Select();
            //DataTable dt = null;
            List<Abonati> listaAbonati = new List<Abonati>();

            try
            {
                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            Abonati abonat = new Abonati(row);
                            listaAbonati.Add(abonat);
                        }
                    }
                    else throw new Exception("No record found!");                    
                }
                else throw new Exception("Querying returned null!");

                return listaAbonati;
            }

            catch (Exception exp)
            {
                throw;
            }          
        }

        public DataTable Select2()
        {
            return dab.Select();
        }

        public DataTable SelectParametrizat(string field, string val)
        {
            return (new DAbonati(field, val)).Select(); // instantierea obiectului pentru interogarile FrmSearchWindow
        }

        public void Update(DataTable dt)
        {
            dab.Update(dt);
        }
    }
}
