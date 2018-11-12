using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AwesomeDBSpace;

namespace AwesomeDB_Test
{
    public partial class GestisciDati : Form
    {
        AwesomeDB adb = new AwesomeDB();

        public GestisciDati()
        {
            InitializeComponent();
        }

        private void GestisciDati_Load(object sender, EventArgs e)
        {
            adb.Connection("nuovodb.mdf");
        }

        private void button_AddData_Click(object sender, EventArgs e)
        {
            adb.Insert("citta", new ADB_Row(new object[] { "'savigliano'", "30000" }));     //Ricordarsi le stringe tra virgolette
            adb.Insert("citta", new ADB_Row(new object[] { "'saluzzo'", "356566" }));
            adb.Insert("citta", new ADB_Row(new string[] { "abitanti", "nome" }, new object[] { "30000", "'savigliano'" }));
            MessageBox.Show("Dati aggiunti");
        }

        private void button_Alldati_Click(object sender, EventArgs e)
        {
            ADB_Result result = adb.All("citta");
            object r = result.data.Row(2).Col(2);
            object w = result.data.Row(0).Col("nome");
            MessageBox.Show("Tutti i dati, " + r.ToString() + " \n " + w.ToString());

            result.data.Row(0).Col("nome", "jam");
            result.data.Row(2, new ADB_Row(new string[] { "10", "ddd", "123" }));
            r = result.data.Row(2).Col(2);
            w = result.data.Row(0).Col("nome");
            MessageBox.Show("Tutti i dati, " + r.ToString() + " \n " + w.ToString());
        }

        private void button_delite_Click(object sender, EventArgs e)
        {
            adb.Remove("citta", 2);
            MessageBox.Show("Dati eliminati");
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            adb.Update("citta", 3, new ADB_Row(new string[] { "nome" }, new object[] { "'moltobene'" }));   //Ricordarsi le stringe tra virgolette
            MessageBox.Show("Dati aggiornati");
        }

        private void button_Ricarica_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = adb.Query("SELECT * FROM citta", AwesomeDB.QueryTypes.query).dt;
        }
    }
}
