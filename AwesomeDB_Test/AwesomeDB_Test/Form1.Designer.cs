namespace AwesomeDB_Test
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_informazioni = new System.Windows.Forms.Button();
            this.button_colonne = new System.Windows.Forms.Button();
            this.button_tabelle = new System.Windows.Forms.Button();
            this.button_dati = new System.Windows.Forms.Button();
            this.button_visteProcedure = new System.Windows.Forms.Button();
            this.button_testVari = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_informazioni
            // 
            this.button_informazioni.Location = new System.Drawing.Point(547, 206);
            this.button_informazioni.Margin = new System.Windows.Forms.Padding(6);
            this.button_informazioni.Name = "button_informazioni";
            this.button_informazioni.Size = new System.Drawing.Size(360, 59);
            this.button_informazioni.TabIndex = 16;
            this.button_informazioni.Text = "Ottieni informazioni";
            this.button_informazioni.UseVisualStyleBackColor = true;
            this.button_informazioni.Click += new System.EventHandler(this.button_informazioni_Click);
            // 
            // button_colonne
            // 
            this.button_colonne.Location = new System.Drawing.Point(547, 135);
            this.button_colonne.Margin = new System.Windows.Forms.Padding(6);
            this.button_colonne.Name = "button_colonne";
            this.button_colonne.Size = new System.Drawing.Size(360, 59);
            this.button_colonne.TabIndex = 15;
            this.button_colonne.Text = "Manipola Colonne";
            this.button_colonne.UseVisualStyleBackColor = true;
            this.button_colonne.Click += new System.EventHandler(this.button_colonne_Click);
            // 
            // button_tabelle
            // 
            this.button_tabelle.Location = new System.Drawing.Point(175, 135);
            this.button_tabelle.Margin = new System.Windows.Forms.Padding(6);
            this.button_tabelle.Name = "button_tabelle";
            this.button_tabelle.Size = new System.Drawing.Size(360, 59);
            this.button_tabelle.TabIndex = 14;
            this.button_tabelle.Text = "Manipola Tabelle";
            this.button_tabelle.UseVisualStyleBackColor = true;
            this.button_tabelle.Click += new System.EventHandler(this.button_tabelle_Click);
            // 
            // button_dati
            // 
            this.button_dati.Location = new System.Drawing.Point(175, 206);
            this.button_dati.Margin = new System.Windows.Forms.Padding(6);
            this.button_dati.Name = "button_dati";
            this.button_dati.Size = new System.Drawing.Size(360, 59);
            this.button_dati.TabIndex = 17;
            this.button_dati.Text = "Gestisci Dati";
            this.button_dati.UseVisualStyleBackColor = true;
            this.button_dati.Click += new System.EventHandler(this.button_dati_Click);
            // 
            // button_visteProcedure
            // 
            this.button_visteProcedure.Location = new System.Drawing.Point(175, 277);
            this.button_visteProcedure.Margin = new System.Windows.Forms.Padding(6);
            this.button_visteProcedure.Name = "button_visteProcedure";
            this.button_visteProcedure.Size = new System.Drawing.Size(360, 59);
            this.button_visteProcedure.TabIndex = 18;
            this.button_visteProcedure.Text = "Viste Procedure";
            this.button_visteProcedure.UseVisualStyleBackColor = true;
            this.button_visteProcedure.Click += new System.EventHandler(this.button_visteProcedure_Click);
            // 
            // button_testVari
            // 
            this.button_testVari.Location = new System.Drawing.Point(175, 554);
            this.button_testVari.Margin = new System.Windows.Forms.Padding(6);
            this.button_testVari.Name = "button_testVari";
            this.button_testVari.Size = new System.Drawing.Size(360, 59);
            this.button_testVari.TabIndex = 19;
            this.button_testVari.Text = "Test Vari";
            this.button_testVari.UseVisualStyleBackColor = true;
            this.button_testVari.Click += new System.EventHandler(this.button_testVari_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 714);
            this.Controls.Add(this.button_testVari);
            this.Controls.Add(this.button_visteProcedure);
            this.Controls.Add(this.button_dati);
            this.Controls.Add(this.button_informazioni);
            this.Controls.Add(this.button_colonne);
            this.Controls.Add(this.button_tabelle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_informazioni;
        private System.Windows.Forms.Button button_colonne;
        private System.Windows.Forms.Button button_tabelle;
        private System.Windows.Forms.Button button_dati;
        private System.Windows.Forms.Button button_visteProcedure;
        private System.Windows.Forms.Button button_testVari;
    }
}

