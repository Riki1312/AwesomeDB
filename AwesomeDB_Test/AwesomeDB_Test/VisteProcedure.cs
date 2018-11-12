using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AwesomeDBSpace.min;

namespace AwesomeDB_Test
{
    public partial class VisteProcedure : Form
    {
        AwesomeDB adb = new AwesomeDB();

        public VisteProcedure()
        {
            InitializeComponent();
        }

        private void VisteProcedure_Load(object sender, EventArgs e)
        {
            adb.Connection("nuovodb.mdf");
        }

        private void button_procedure_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = adb.StoredProcedure("test", new string[,] { { "parametro", "1" } }).dt;
            MessageBox.Show("Procedure richiamata");
        }

        private void button_addView_Click(object sender, EventArgs e)
        {
            if (!adb.LowLevel.TableExist("vistaTest"))
            {
                //adb.AddView("vistaTest", "citta", "nome, abitanti");
                adb.AddView("vistaTest", "citta", new string[] { "nome", "abitanti" });
                MessageBox.Show("Vista aggiunta");
            }
            else
                MessageBox.Show("Vista già presente");

            dataGridView1.DataSource = adb.All("vistaTest").dt;
        }

        private void button_remView_Click(object sender, EventArgs e)
        {
            adb.RemoveView("vistaTest");
            MessageBox.Show("Vista rimossa");
        }
    }
}
