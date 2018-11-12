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

namespace AwesomeDBSpace.min
{
    /*
    Aggiungere modulo: (ADB_AlteredTable o ADB_Information)
        Aggiungere classe modulo
        Rimuovere i commenti a fianco di "MODULE: ..."
    
    Pulizia:
        Se non si eseguono operazioni con le tabelle: rimuovere tutto il contenuto di "//- TABLE OPERATIONS ["
        Se non si eseguono operazioni con i dati: rimuovere tutto il contenuto di "//- DATA OPERATIONS ["
        Se non si usano stored procedure e viste: rimuovere tutto il contenuto di "//- ADDDTIONAL ["

        Rimuovere i commenti dei moduli non utilizzati: "MODULE: ..."
        (Rinominare la classe e il namespace)
        (Rimuovere commenti inutili, !quello al fondo!)
    */

    class AwesomeDB
    {
        public ADB_LowLevel LowLevel;

        /*MODULE: ADB_AlteredTable*/ //public ADB_AlteredTable AlteredTable;
        /*MODULE: ADB_Information*/ //public ADB_Information Information;

        public ADB_Settings Settings = new ADB_Settings();
        public enum QueryTypes { query, notquery, scalar };

        public AwesomeDB() { /**/ }

        //Si collega a un database parametri: nome, [percorso]
        public bool Connection(string dbName, string dbPath = null)
        {
            dbPath = dbPath ?? Application.StartupPath;
            LowLevel = new ADB_LowLevel(Path.Combine(dbPath, dbName));

            /*MODULE: ADB_AlteredTable*/ //AlteredTable = new ADB_AlteredTable(LowLevel);
            /*MODULE: ADB_Information*/ //Information = new ADB_Information(LowLevel);

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

        //- ADDDTIONAL [

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

        //- ADDDTIONAL ]

        //- DATA OPERATIONS [

        //Rimuove una riga parametri: nome tabella, id riga da rimuovere
        public ADB_Result Remove(string tbName, int id)
        {
            Query("DELETE FROM " + tbName + " WHERE " + Settings.NameColumnId + "=" + id, QueryTypes.notquery);
            return new ADB_Result(removedRecords: 1);
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
        //Ottiene tutti i dati di una tabella parametri: nome tabella
        public ADB_Result All(string tbName)
        {
            return Query("SELECT * FROM " + tbName);
        }

        //- DATA OPERATIONS ]

        //- TABLE OPERATIONS [

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

        //- TABLE OPERATIONS ]
    }

    class ADB_LowLevel
    {
        public ADOSQLServer2017.ADOSQLServer2017 db;

        public ADB_LowLevel(string dbPath)
        {
            db = new ADOSQLServer2017.ADOSQLServer2017(dbPath);
        }

        //- ADDDTIONAL [

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

        //- ADDDTIONAL ]

        //- TABLE OPERATIONS [

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

        //- TABLE OPERATIONS ]
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
}

//

    /*
    * ESEMPI:
    * view ------>          CREATE VIEW vw_YourView AS SELECT YOurColumn FROM YourTable
    *
    * STORED PROCEDURE -->  CREATE PROCEDURE [dbo].[ProceduraCreaTabella] 
    *                       @nomeSquadra VARCHAR(30) 
    *                       AS 
    *                       IF OBJECT_ID('PartiteMese', 'U') IS NOT NULL DROP TABLE PartiteMese;
    *                       CREATE TABLE PartiteMese
    *                       (
    *                           NomeS1 VARCHAR(30) NOT NULL,
    *                           NomeS2 VARCHAR(30) NOT NULL,
    *                           Data DATE
    *                       )
    *
    *                       INSERT INTO PartiteMese(NomeS1, NomeS2, Data)
    *                            SELECT s1.nome, s2.nome, Data
    *                            FROM Squadre as s1, Squadre as s2, Partite
    *                            WHERE Partite.idSquadraCasa = s1.idSquadra AND
    *                            Partite.idSquadraTrasferta = s2.idSquadra AND
    *                            (@nomeSquadra = s1.Nome OR @nomeSquadra = s2.Nome) AND
    *                            MONTH(Data) = MONTH(GETDATE());
    *
    *                       SELECT * FROM PartiteMese;
    *                       RETURN 0  
    *
    *
    * TRIGGER ------>       CREATE TRIGGER [dbo].[Trigger_NGiocatori] ON [dbo].[Giocatori] 
    *                       FOR DELETE, INSERT, UPDATE 
    *                       AS 
    *                       BEGIN 
    *                           SET NoCount ON 
    *                           declare @squadra int;
    *                           declare @squadraOld int;
    *                           
    *                       IF  EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    *                           BEGIN
    *                               SELECT @squadra = idSquadra FROM inserted;
    *                               UPDATE Squadre SET NGiocatori = NGiocatori + 1 WHERE idSquadra = @squadra;
    *                               SELECT @squadraOld = idSquadra FROM deleted;
    *                               UPDATE Squadre SET NGiocatori = NGiocatori - 1 WHERE idSquadra = @squadraOld;
    *                           END
    *
    *
    *                       ELSE IF  EXISTS (SELECT * FROM inserted)
    *                           BEGIN
    *                               SELECT @squadra = idSquadra FROM inserted;
    *                               UPDATE Squadre SET NGiocatori = NGiocatori + 1 WHERE idSquadra = @squadra;
    *                           END
    *
    *                       ELSE IF  EXISTS (SELECT * FROM deleted)
    *                           BEGIN
    *                               SELECT @squadra = idSquadra FROM deleted;
    *                               UPDATE Squadre SET NGiocatori = NGiocatori - 1 WHERE idSquadra = @squadra;
    *                           END         
    *                       
    *                       END
    *                       GO
    */
