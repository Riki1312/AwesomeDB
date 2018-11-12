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
    public partial class ManipolaColonne : Form
    {
        AwesomeDB adb = new AwesomeDB();

        public ManipolaColonne()
        {
            InitializeComponent();
        }

        private void ManipolaColonne_Load(object sender, EventArgs e)
        {
            adb.Connection("nuovodb.mdf");
        }

        private void button_addColon_Click(object sender, EventArgs e)
        {
            adb.AlteredTable.AddColon("studenti", "colore", "int");
            MessageBox.Show("Fatto");
        }

        private void button_rimColon_Click(object sender, EventArgs e)
        {
            adb.AlteredTable.RemoveColon("studenti", "colore");
            MessageBox.Show("Fatto");
        }

        private void button_cColon_Click(object sender, EventArgs e)
        {
            adb.AlteredTable.ChangeColon("studenti", "colore", newColonName: "pippo");
            adb.AlteredTable.ChangeColon("studenti", "pippo", newColonType: "char(10)");
            MessageBox.Show("Fatto");
        }
    }
}
