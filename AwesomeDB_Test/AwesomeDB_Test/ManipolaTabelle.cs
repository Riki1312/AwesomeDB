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
    public partial class ManipolaTabelle : Form
    {
        AwesomeDB adb = new AwesomeDB();

        public ManipolaTabelle()
        {
            InitializeComponent();
        }

        private void button_CreaDb_Click(object sender, EventArgs e)
        {
            string dbname = adb.CreateDB("nuovodb");
            MessageBox.Show("DB creato");
        }

        private void button_CreaTabella_Click(object sender, EventArgs e)
        {
            adb.Connection("nuovodb.mdf");

            adb.AddTable(new ADB_TableModel(
                name: "citta",
                record: new string[] { "id int", "nome varchar(50)", "abitanti int" },
                primarykey: "id",
                primarykeyIdentity: true
            ));

            adb.AddTable(new ADB_TableModel(
                name: "studenti",
                record: new string[] {
                    "id int",
                    "nome varchar(30)",
                    "cognome varchar(30)",
                    "idcitta int"
                },
                primarykey: "id",
                primarykeyIdentity: true,
                foreignkey: new string[,] {
                    { "idcitta", "citta(id)" }
                }
            ));
            MessageBox.Show("Tabella creata");

            adb.AddTable("test", "id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, prova VARCHAR(30)");
            MessageBox.Show("Tabella test creata");
        }

        private void button_rimuoviTab_Click(object sender, EventArgs e)
        {
            adb.RemoveTable("ciao");
            MessageBox.Show("Tabella rimossa");
        }

        private void button_rinominaTab_Click(object sender, EventArgs e)
        {
            adb.RenameTable("test", "ciao");
            MessageBox.Show("Tabella rinominata");
        }

        private void ManipolaTabelle_Load(object sender, EventArgs e)
        {

        }
    }
}
