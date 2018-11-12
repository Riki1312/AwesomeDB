using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwesomeDB_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_tabelle_Click(object sender, EventArgs e)
        {
            ManipolaTabelle frm = new ManipolaTabelle();
            frm.Show();
        }

        private void button_colonne_Click(object sender, EventArgs e)
        {
            ManipolaColonne frm = new ManipolaColonne();
            frm.Show();
        }

        private void button_dati_Click(object sender, EventArgs e)
        {
            GestisciDati frm = new GestisciDati();
            frm.Show();
        }

        private void button_informazioni_Click(object sender, EventArgs e)
        {
            OttieniInformazioni frm = new OttieniInformazioni();
            frm.Show();
        }

        private void button_visteProcedure_Click(object sender, EventArgs e)
        {
            VisteProcedure frm = new VisteProcedure();
            frm.Show();
        }

        private void button_testVari_Click(object sender, EventArgs e)
        {
            TestVari frm = new TestVari();
            frm.Show();
        }
    }
}
