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

/*

INSERT INTO table_name (column1, column2, column3, ...)
VALUES (value1, value2, value3, ...);

UPDATE table_name
SET column1 = value1, column2 = value2, ...
WHERE condition;

DELETE FROM table_name WHERE condition;

CREATE VIEW view_name AS
SELECT column1, column2, ...
FROM table_name
WHERE condition;

    //

    SELECT column1, column2, ...
    FROM table_name
    ORDER BY column1, column2, ... ASC|DESC;

    SELECT DISTINCT column1, column2, ...
    FROM table_name;

    SELECT * FROM Customers
    WHERE CustomerName NOT LIKE 'a%';

    SELECT column_name(s)
    FROM table_name
    WHERE column_name BETWEEN value1 AND value2;


    CREATE TABLE Persons (
    PersonID int,
    LastName varchar(255),
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255) 
    );

    CREATE TABLE Orders (
    OrderID int NOT NULL,
    OrderNumber int NOT NULL,
    PersonID int,
    PRIMARY KEY (OrderID),
    FOREIGN KEY (PersonID) REFERENCES Persons(PersonID)
    );

    //

    SELECT column_name(s)
    FROM table_name
    WHERE EXISTS
    (SELECT column_name FROM table_name WHERE condition);

    DROP TABLE table_name;

    ALTER TABLE Customers
    ADD Email varchar(255);
*/

namespace AwesomeDB_Test
{
    public partial class TestVari : Form
    {
        AwesomeDB adb = new AwesomeDB();

        public TestVari()
        {
            InitializeComponent();
        }

        private void TestVari_Load(object sender, EventArgs e)
        {
            adb.Connection("Campionato.mdf");
        }

        private void button_SoloViste_Click(object sender, EventArgs e)
        {
            dataGridView_tabelle.DataSource = adb.Query("SELECT TABLE_NAME, TABLE_TYPE FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='VIEW'", AwesomeDB.QueryTypes.query).dt;
        }

        private void button_SoloTabelle_Click(object sender, EventArgs e)
        {
            dataGridView_tabelle.DataSource = adb.Query("SELECT TABLE_NAME, TABLE_TYPE FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'", AwesomeDB.QueryTypes.query).dt;
        }

        private void button_Tutto_Click(object sender, EventArgs e)
        {
            dataGridView_tabelle.DataSource = adb.Query("SELECT TABLE_NAME, TABLE_TYPE FROM INFORMATION_SCHEMA.TABLES", AwesomeDB.QueryTypes.query).dt;
        }

        private void dataGridView_tabelle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string tableName = dataGridView_tabelle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            //adb.Settings.DebugMode = false;
            dataGridView_dettagli.DataSource = adb.All(tableName).dt;
        }

        private void button_insRuolo_Click(object sender, EventArgs e)
        {
            DataTable dt = adb.StoredProcedure("ProceduraCreaTabella", new string[,] {
                { "nomeSquadra", "Bari" }
            }).dt;

            dataGridView_dettagli.DataSource = dt;
        }

        private void button_CreaVista_Click(object sender, EventArgs e)
        {
            //Creare una view
            if (!adb.LowLevel.TableExist("ViewPartiteGoal"))
            {
                dataGridView_dettagli.DataSource = adb.Query(
                    "CREATE VIEW ViewPartiteGoal AS SELECT GoalS1, GoalS2 FROM Partite",
                    AwesomeDB.QueryTypes.notquery
                ).then.Query("SELECT * FROM ViewPartiteGoal").dt;
            }
        }
    }
}
