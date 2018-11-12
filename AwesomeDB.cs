using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.IO;

//V1.3

namespace AwesomeDBSpace
{
    class AwesomeDB
    {
        public ADB_LowLevel LowLevel;
        public ADB_AlteredTable AlteredTable;
        public ADB_Information Information;

        public ADB_Settings Settings = new ADB_Settings();
        public enum QueryTypes { query, notquery, scalar };

        public AwesomeDB() { /**/ }

        //Crea un nuovo database parametri: nome, [percorso]
        public string CreateDB(string dbName, string dbPath = null)
        {
            if (!ADB_LowLevel.DatabaseExists(dbName))
            {
                dbPath = dbPath ?? Application.StartupPath;

                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30";

                string[] files = { Path.Combine(dbPath, dbName + ".mdf"), Path.Combine(dbPath, dbName + ".ldf") };
                string query = "CREATE DATABASE " + dbName +
                    " ON PRIMARY" +
                    " (NAME = " + dbName + "_data," +
                    " FILENAME = '" + files[0] + "'," +
                    " SIZE = 3MB," +
                    " MAXSIZE = 10MB," +
                    " FILEGROWTH = 10%)" +

                    " LOG ON" +
                    " (NAME = " + dbName + "_log," +
                    " FILENAME = '" + files[1] + "'," +
                    " SIZE = 1MB," +
                    " MAXSIZE = 5MB," +
                    " FILEGROWTH = 10%)" +
                    ";";

                var conn = new SqlConnection(connectionString);
                var command = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception(ex.Message); }
                finally { if (conn.State == ConnectionState.Open) { conn.Close(); } }
            }
            return dbName + ".mdf";
        }

        //Si collega a un database parametri: nome, [percorso]
        public bool Connection(string dbName, string dbPath = null)
        {
            dbPath = dbPath ?? Application.StartupPath;
            LowLevel = new ADB_LowLevel(Path.Combine(dbPath, dbName));
            AlteredTable = new ADB_AlteredTable(LowLevel);
            Information = new ADB_Information(LowLevel);
            return true;
        }

        //Esegue una query parametri: testo della query, tipo di query
        public ADB_Result Query(string query, QueryTypes queryTypes = QueryTypes.query)
        {
            try
            {
                ADB_Result ret = null;
                SqlCommand cmd = new SqlCommand();

                switch (queryTypes)
                {
                    case QueryTypes.query:
                        cmd.CommandText = query;
                        ret = new ADB_Result(then: this, dataTable: LowLevel.db.EseguiQuery(cmd));
                        break;
                    case QueryTypes.notquery:
                        cmd.CommandText = query;
                        ret = new ADB_Result(then: this, changedRecords: LowLevel.db.EseguiNonQuery(cmd));
                        break;
                    case QueryTypes.scalar:
                        cmd.CommandText = query;
                        ret = new ADB_Result(then: this, singleData: LowLevel.db.EseguiScalar(cmd));
                        break;
                }
                return ret;
            }
            catch(Exception ex)
            {
                if (Settings.DebugMode) throw new Exception(ex.Message);
                else return new ADB_Result(then: this, errorsMessage: ex.Message);
            }
        }

        //Esegue una stored procedure parametri: nome procedura, parametri procedura
        public ADB_Result StoredProcedure(string name, string[,] parameters = null)
        {
            try
            {
                ADB_Result ret = null;
                parameters = parameters ?? new string[,] { { "", "" } };  //new string[,] { { "nomeParametro", "valore" } };

                ret = new ADB_Result(then: this, dataTable: LowLevel.RunWithParameters(CommandType.StoredProcedure, name, parameters));
                return ret;
            }
            catch (Exception ex)
            {
                if (Settings.DebugMode) throw new Exception(ex.Message);
                else return new ADB_Result(then: this, errorsMessage: ex.Message);
            }
        }

        //Aggiunge una nuova view parametri: nome, tabella, campi separati da virgola
        public ADB_Result AddView(string name, string from, string select)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "CREATE VIEW " + name;
                cmd.CommandText += " AS SELECT " + select + " FROM " + from;
                LowLevel.db.EseguiNonQuery(cmd);

                return new ADB_Result(then: this);
            }
            catch (Exception ex)
            {
                if (Settings.DebugMode) throw new Exception(ex.Message);
                else return new ADB_Result(then: this, errorsMessage: ex.Message);
            }
        }
        //Aggiunge una nuova view parametri: nome, tabella, campi separati da virgola
        public ADB_Result AddView(string name, string from, string[] select)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "CREATE VIEW " + name + " AS SELECT ";
                for (int i = 0; i < select.Length; i++)
                {
                    cmd.CommandText += select[i];
                    if (i != select.Length - 1)
                        cmd.CommandText += ", ";
                }
                cmd.CommandText += " FROM " + from;
                LowLevel.db.EseguiNonQuery(cmd);

                return new ADB_Result(then: this);
            }
            catch (Exception ex)
            {
                if (Settings.DebugMode) throw new Exception(ex.Message);
                else return new ADB_Result(then: this, errorsMessage: ex.Message);
            }
        }
        //Rimuove una tabella view: nome (Cancellazione di tutti i dati contenuti)
        public ADB_Result RemoveView(string name)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DROP VIEW IF EXISTS " + name;
                LowLevel.db.EseguiNonQuery(cmd);

                return new ADB_Result(then: this);
            }
            catch (Exception ex)
            {
                if (Settings.DebugMode) throw new Exception(ex.Message);
                else return new ADB_Result(then: this, errorsMessage: ex.Message);
            }
        }

        //Rimuove una riga parametri: nome tabella, id riga da rimuovere
        public ADB_Result Remove(string tbName, int id)
        {
            Query("DELETE FROM " + tbName + " WHERE " + Settings.NameColumnId + "=" + id, QueryTypes.notquery);
            return new ADB_Result(removedRecords: 1);
        }
        //Rimuove più rige parametri: nome tabella, id rige da rimuovere
        public ADB_Result Remove(string tbName, int[] idArray)
        {
            return new ADB_Result(removedRecords: idArray.Length);
        }

        //Modifica una riga parametri: nome tabella, id riga da modificare, nuva riga
        public ADB_Result Update(string tbName, int id, ADB_Row rowData)
        {
            if (rowData.UseColons)
            {
                string q = "UPDATE " + tbName + " SET ";
                for (int i = 0; i < rowData.data_colonsNames.Count; i++)
                {
                    q += rowData.data_colonsNames[i] + "=" + rowData.data_values[i];
                    if (i < rowData.data_colonsNames.Count - 1)
                        q += ", ";
                }
                q += " WHERE " + Settings.NameColumnId + "=" + id;

                Query(q, QueryTypes.notquery);
                return new ADB_Result(changedRecords: 1);
            }
            else
                throw new Exception("Error Update: meaningless parameters");
        }
        //Modifica più rige parametri: nome tabella, id rige da modificare, nuvi dati (formato: nome colonna, valore). (Tutte le rige modificate con gli stessi dati)
        public ADB_Result Update(string tbName, int[] idArray, ADB_Row newRow)
        {
            return new ADB_Result(changedRecords: idArray.Length);
        }
        //Modifica più rige parametri: nome tabella, id rige da modificare, nuvi dati. (Per ogni riga un dato diverso)
        public ADB_Result Update(string tbName, int[] idArray, ADB_Data data)
        {
            return new ADB_Result(changedRecords: idArray.Length);
        }

        //Inserisce una nuova riga parametri: nome tabella, nuovi riga (Ricordarsi le stringe tra virgolette)
        public ADB_Result Insert(string tbName, ADB_Row rows)
        {
            string q;
            if (rows.UseColons)
            {
                q = "INSERT INTO " + tbName + " (";
                for (int i = 0; i< rows.data_colonsNames.Count; i++)
                {
                    q += rows.data_colonsNames[i];
                    if (i != rows.data_colonsNames.Count - 1)
                        q += ", ";
                }
                q += ") VALUES (";
                for (int i = 0; i < rows.data_values.Count; i++)
                {
                    q += rows.data_values[i];
                    if (i != rows.data_values.Count - 1)
                        q += ", ";
                }
                q += ")";
            }
            else
            {
                q = "INSERT INTO " + tbName + " ";
                q += "VALUES (";
                for (int i = 0; i < rows.data_values.Count; i++)
                {
                    q += rows.data_values[i];
                    if (i != rows.data_values.Count - 1)
                        q += ", ";
                }
                q += ")";
            }
            Query(q, QueryTypes.notquery);

            return new ADB_Result(addedRecords: rows.data_values.Count);
        }
        //Inserisce delle nuove rige parametri: nome tabella, nuovi dati
        public ADB_Result Insert(string tbName, ADB_Data data)
        {
            return new ADB_Result(addedRecords: data.nRows);
        }

        //Ottiene tutti i dati di una tabella parametri: nome tabella
        public ADB_Result All(string tbName)
        {
            return Query("SELECT * FROM " + tbName);
        }

        //Aggiunge una nuova tabella parametri: tabella
        public ADB_Result AddTable(string name, string body)
        {
            if (!LowLevel.TableExist(name))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "CREATE TABLE " + name;

                cmd.CommandText += "(";
                cmd.CommandText += body;
                cmd.CommandText += ")";
                LowLevel.db.EseguiNonQuery(cmd);

                return new ADB_Result();
            }
            else
                return new ADB_Result(errorsMessage: "Table " + name + "already exists");
        }
        //Aggiunge una nuova tabella parametri: tabella
        public ADB_Result AddTable(ADB_TableModel table)
        {
            if (!LowLevel.TableExist(table.name))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "CREATE TABLE " + table.name;

                cmd.CommandText += "(";
                for (int i = 0; i < table.record.Length; i++)
                {
                    cmd.CommandText += table.record[i];
                    if (table.primarykeyIdentity && table.record[i].Split(' ')[0] == table.primarykey)
                        cmd.CommandText += " PRIMARY KEY identity(1, 1) ";
                    if (i != table.record.Length - 1)
                        cmd.CommandText += ", ";
                }
                for (int i = 0; i < table.foreingkey.Length / 2; i++)
                {
                    if (i == 0)
                        cmd.CommandText += ", ";
                    cmd.CommandText += "FOREIGN KEY (" + table.foreingkey[i, 0] + ") REFERENCES " + table.foreingkey[i, 1];
                    if (i != table.foreingkey.Length / 2 - 1)
                        cmd.CommandText += ", ";
                }
                cmd.CommandText += ")";
                LowLevel.db.EseguiNonQuery(cmd);

                return new ADB_Result();
            }
            else
                return new ADB_Result(errorsMessage: "Table " + table.name + "already exists");
        }
        //Rimuove una tabella parametri: tabella (Cancellazione di tutti i dati contenuti)
        public ADB_Result RemoveTable(string name)
        {
            if (LowLevel.TableExist(name))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DROP TABLE " + name;
                LowLevel.db.EseguiNonQuery(cmd);

                return new ADB_Result();
            }
            else
                return new ADB_Result(errorsMessage: "Table " + name + "not exists");
        }
        //Rinomina una tabella parametri: tabella, nuovo nome
        public ADB_Result RenameTable(string name, string newName)
        {
            if (LowLevel.TableExist(name))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_RENAME '" + name + "', '" + newName + "'";
                LowLevel.db.EseguiNonQuery(cmd);

                return new ADB_Result();
            }
            else
                return new ADB_Result(errorsMessage: "Table " + name + "not exists");
        }
    }

    class ADB_Information
    {
        private ADB_LowLevel LowLevel;

        public ADB_Information(ADB_LowLevel lowLevel) { LowLevel = lowLevel; }

        public string[] TablesName()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
                DataTable dt = LowLevel.db.EseguiQuery(cmd);

                return dt.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public string[] ColonNames(string tbName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tbName + "'";
                DataTable dt = LowLevel.db.EseguiQuery(cmd);

                return dt.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public string ColonType(string tbName, string clName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tbName + "' AND COLUMN_NAME = '" + clName + "'";
                DataTable dt = LowLevel.db.EseguiQuery(cmd);

                return dt.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray()[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }

    class ADB_AlteredTable
    {
        private ADB_LowLevel LowLevel;

        public ADB_AlteredTable(ADB_LowLevel lowLevel) { LowLevel = lowLevel; }

        public ADB_Result AddColon(string name, string colonName, string colonType)
        {
            if (LowLevel.TableExist(name))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "ALTER TABLE " + name + " ADD " + colonName + " " + colonType;
                LowLevel.db.EseguiNonQuery(cmd);

                return new ADB_Result();
            }
            else
                return new ADB_Result(errorsMessage: "Table " + name + "not exists");
        }

        public ADB_Result RemoveColon(string name, string colonName)
        {
            if (LowLevel.TableExist(name))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "ALTER TABLE " + name + " DROP COLUMN " + colonName;
                LowLevel.db.EseguiNonQuery(cmd);

                return new ADB_Result();
            }
            else
                return new ADB_Result(errorsMessage: "Table " + name + "not exists");
        }

        public ADB_Result ChangeColon(string name, string colonName, string newColonType = null, string newColonName = null)
        {
            if (LowLevel.TableExist(name))
            {
                SqlCommand cmd = new SqlCommand();

                if (newColonType != null)
                    cmd.CommandText = "ALTER TABLE " + name + " ALTER COLUMN " + colonName + " " + newColonType;
                else if (newColonName != null)
                    cmd.CommandText = "SP_RENAME '" + name + "." + colonName + "', '" + newColonName + "', 'COLUMN'";
                else
                    throw new Exception("Error ChangeColon: meaningless parameters");

                LowLevel.db.EseguiNonQuery(cmd);

                return new ADB_Result();
            }
            else
                return new ADB_Result(errorsMessage: "Table " + name + "not exists");
        }
    }

    class ADB_LowLevel
    {
        public ADOSQLServer2017.ADOSQLServer2017 db;

        public ADB_LowLevel(string dbPath)
        {
            db = new ADOSQLServer2017.ADOSQLServer2017(dbPath);
        }

        public DataTable RunWithParameters(CommandType cmdType, string cmdText, string[,] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;

            for (int i = 0; i < parameters.Length / 2; i++)
            {
                cmd.Parameters.AddWithValue("@" + parameters[i, 0], parameters[i, 1]);
            }

            return db.EseguiQuery(cmd);
        }

        public bool TableExist(string name)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM INFORMATION_SCHEMA.TABLES ";
                cmd.CommandText += " WHERE TABLE_SCHEMA = 'dbo'  AND TABLE_NAME = @nome ";
                cmd.Parameters.AddWithValue("@nome", name);
                DataTable dt = db.EseguiQuery(cmd);

                return !(dt.Rows.Count == 0);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public static bool DatabaseExists(string name)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30";
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand($"SELECT db_id('{name}')", connection))
                {
                    connection.Open();
                    return (command.ExecuteScalar() != DBNull.Value);
                }
            }
        }
    }

    class ADB_Settings
    {
        public string NameColumnId = "id";
        public bool DebugMode = true;   //Non ancora implementata completamente
    }

    class ADB_Data
    {
        private List<string> data_colonsNames = new List<string>();
        private List<ADB_Row> data_rows = new List<ADB_Row>();

        public string[] colonsNames { get { return data_colonsNames.ToArray(); } }
        public List<object[]> dataRows { get { return data_rows.Select(x => x.data_values.ToArray()).ToList(); } }

        public int nRows { get { return data_rows.Count; } }
        public int nColons { get { return data_colonsNames.Count; } }

        public ADB_Data(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Columns.Count; i++)
                data_colonsNames.Add(dataTable.Columns[i].ColumnName);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ADB_Row row = new ADB_Row(dataTable.Rows[i]);
                data_rows.Add(row);
            }
        }
        public ADB_Data(string[] colonsNames, ADB_Row[] rows)
        {
            data_colonsNames = colonsNames.ToList();
            data_rows = rows.ToList();
        }
        public ADB_Data(List<string> colonsNames, List<ADB_Row> rows)
        {
            data_colonsNames = colonsNames;
            data_rows = rows;
        }

        public DataTable DataTable()
        {
            DataTable table = new DataTable();

            for (int i = 0; i < data_colonsNames.Count; i++)
            {
                DataColumn column = new DataColumn();
                column.ColumnName = data_colonsNames[i];
                table.Columns.Add(column);
            }

            for (int i = 0; i < data_rows.Count; i++)
            {
                DataRow row = table.NewRow();
                for (int j = 0; j < data_rows[i].data_values.Count; j++)
                    row[j] = data_rows[i].data_values[j];
                table.Rows.Add(row);
            }

            return table;
        }

        public ADB_Row Row(int index)
        {
            data_rows[index].data_colonsNames = data_colonsNames;
            return data_rows[index];
        }
        public ADB_Row Row(int index, ADB_Row value)
        {
            data_rows[index].data_colonsNames = data_colonsNames;
            data_rows[index] = value;
            return data_rows[index];
        }
    }

    class ADB_Row
    {
        public List<string> data_colonsNames;
        public List<object> data_values;
        private bool useColons;

        public bool UseColons { get { return useColons; } }

        public ADB_Row(DataRow row)
        {
            data_values = row.ItemArray.ToList();
        }

        public ADB_Row(string[] colonsNames, object[] values)
        {
            useColons = true;
            data_colonsNames = colonsNames.ToList();
            data_values = values.ToList();
        }
        public ADB_Row(object[] values)
        {
            useColons = false;
            data_values = values.ToList();
        }
        public ADB_Row(List<string> colonsNames, List<object> values)
        {
            useColons = true;
            data_colonsNames = colonsNames;
            data_values = values;
        }
        public ADB_Row(List<object> values)
        {
            useColons = false;
            data_values = values.ToList();
        }

        public object Col(int index) { return data_values[index]; }
        public object Col(int index, object value) { data_values[index] = value; return data_values[index]; }
        public object Col(string index) { return data_values[data_colonsNames.IndexOf(index)]; }
        public object Col(string index, object value) { data_values[data_colonsNames.IndexOf(index)] = value; return data_values[data_colonsNames.IndexOf(index)]; }
    }

    class ADB_Result
    {
        private AwesomeDB res_then;
        private DataTable res_dataTable;
        private ADB_Data res_data;
        private int res_changedRecords;
        private int res_removedRecords;
        private int res_addedRecords;
        private object res_singleData;
        private bool res_errors;
        private string res_errorsMessage;

        public AwesomeDB then { get { return res_then; } }
        public DataTable dt { get { return res_dataTable; } }
        public ADB_Data data { get { return res_data; } }
        public int changedRecords { get { return res_changedRecords; } }
        public int removedRecords { get { return res_removedRecords; } }
        public int addedRecords { get { return res_addedRecords; } }
        public object singleData { get { return res_singleData; } }
        public bool errors { get { return res_errors; } }
        public string errorsMessage { get { return res_errorsMessage; } }

        public ADB_Result(AwesomeDB then = null, DataTable dataTable = null, int changedRecords = -1, int removedRecords = -1, int addedRecords = -1, object singleData = null, string errorsMessage = null)
        {
            res_then = then;
            if (dataTable != null)
                res_data = new ADB_Data(dataTable);
            res_dataTable = dataTable;
            res_changedRecords = changedRecords;
            res_removedRecords = removedRecords;
            res_addedRecords = addedRecords;
            res_singleData = singleData;
            res_errorsMessage = errorsMessage;
            if (errorsMessage == null)
                res_errors = false;
            else
                res_errors = true;
        }
    }

    class ADB_TableModel
    {
        private string tb_name;
        private string[] tb_record;
        private string tb_primarykey;
        private bool tb_primarykeyIdentity;
        string[,] tb_foreingkey;

        public string name { get { return tb_name; } }
        public string[] record { get { return tb_record; } }
        public string primarykey { get { return tb_primarykey; } }
        public bool primarykeyIdentity { get { return tb_primarykeyIdentity; } }
        public string[,] foreingkey { get { return tb_foreingkey; } }

        public ADB_TableModel(string name = "newtable", string[] record = null, string primarykey = null, bool primarykeyIdentity = true, string[,] foreignkey = null)
        {
            record = record ?? new string[] { "record0 int" };
            primarykey = primarykey ?? "record0";
            foreignkey = foreignkey ?? new string[,] { { } };  //new string[,] { { "record", "table(record)" } };

            tb_name = name;
            tb_record = record;
            tb_primarykey = primarykey;
            tb_primarykeyIdentity = primarykeyIdentity;
            tb_foreingkey = foreignkey;
        }
    }
}

//