using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAbonati
    {
        // obiect folosit pentru operatiuni pe BD initiate in GUI cu button1 (select) si button2 (insert, delete, update)

        DataTable dt = new DataTable("Agenda");

        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master; Integrated Security=True;Connect Timeout=30; Encrypt=False; TrustServerCertificate=True; ApplicationIntent=ReadWrite; MultiSubnetFailover=False";
        
        SqlDataAdapter adapter;

        public DAbonati()
        {
            string queryString = "Select * from Agenda";
            
            try
            {
                adapter = new SqlDataAdapter(queryString, connString);
                adapter.Fill(dt);
            }
            catch
            {
                throw;
            }

            SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
        }

        // constructor cu parametri; folosit pentru instantierea obiectului care realizeaza select-urile din FrmSearchWindow

        public DAbonati(string field, string val)
        {
            string queryString2 = "";

            if (field.Equals("Nume"))
            {
                queryString2 = "Select * from Agenda where Nume = \'" + val + "\'";
            }
            else if (field.Equals("Prenume"))
            {
                queryString2 = "Select * from Agenda where Prenume = \'" + val + "\'";
            }
            else if (field.Equals("Telefon"))
            {
                queryString2 = "Select * from Agenda where Telefon = \'" + val + "\'";
            }
            else
            {
                queryString2 = "Select * from Agenda";
            }

            adapter = new SqlDataAdapter(queryString2, connString);
            adapter.Fill(dt);
        }


        public DataTable Select()
        {
            return dt;
        }

        public void Update(DataTable dt)
        {
            adapter.Update(dt);
        }
    }
}
