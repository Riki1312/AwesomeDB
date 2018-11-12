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
    public partial class OttieniInformazioni : Form
    {
        AwesomeDB adb = new AwesomeDB();

        public OttieniInformazioni()
        {
            InitializeComponent();
        }

        private void OttieniInformazioni_Load(object sender, EventArgs e)
        {
            adb.Connection("nuovodb.mdf");
        }

        private void button_tName_Click(object sender, EventArgs e)
        {
            string[] s = adb.Information.TablesName();
            MessageBox.Show("Nomi tabelle");
        }

        private void button_cName_Click(object sender, EventArgs e)
        {
            string[] s = adb.Information.ColonNames("citta");
            MessageBox.Show("Nomi colonne");
        }

        private void button_cTipe_Click(object sender, EventArgs e)
        {
            string s = adb.Information.ColonType("citta", "nome");
            MessageBox.Show("Tipo colonna, " + s);
        }
    }
}
