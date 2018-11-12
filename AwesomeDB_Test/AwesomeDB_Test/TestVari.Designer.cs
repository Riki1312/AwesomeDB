namespace AwesomeDB_Test
{
    partial class TestVari
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_CreaVista = new System.Windows.Forms.Button();
            this.button_insRuolo = new System.Windows.Forms.Button();
            this.button_SoloTabelle = new System.Windows.Forms.Button();
            this.button_Tutto = new System.Windows.Forms.Button();
            this.dataGridView_dettagli = new System.Windows.Forms.DataGridView();
            this.dataGridView_tabelle = new System.Windows.Forms.DataGridView();
            this.button_SoloViste = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dettagli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tabelle)).BeginInit();
            this.SuspendLayout();
            // 
            // button_CreaVista
            // 
            this.button_CreaVista.Location = new System.Drawing.Point(1395, 191);
            this.button_CreaVista.Margin = new System.Windows.Forms.Padding(6);
            this.button_CreaVista.Name = "button_CreaVista";
            this.button_CreaVista.Size = new System.Drawing.Size(213, 55);
            this.button_CreaVista.TabIndex = 13;
            this.button_CreaVista.Text = "Crea vista";
            this.button_CreaVista.UseVisualStyleBackColor = true;
            this.button_CreaVista.Click += new System.EventHandler(this.button_CreaVista_Click);
            // 
            // button_insRuolo
            // 
            this.button_insRuolo.Location = new System.Drawing.Point(1395, 124);
            this.button_insRuolo.Margin = new System.Windows.Forms.Padding(6);
            this.button_insRuolo.Name = "button_insRuolo";
            this.button_insRuolo.Size = new System.Drawing.Size(341, 55);
            this.button_insRuolo.TabIndex = 12;
            this.button_insRuolo.Text = "Crea tabella nome squadra";
            this.button_insRuolo.UseVisualStyleBackColor = true;
            this.button_insRuolo.Click += new System.EventHandler(this.button_insRuolo_Click);
            // 
            // button_SoloTabelle
            // 
            this.button_SoloTabelle.Location = new System.Drawing.Point(220, 35);
            this.button_SoloTabelle.Margin = new System.Windows.Forms.Padding(6);
            this.button_SoloTabelle.Name = "button_SoloTabelle";
            this.button_SoloTabelle.Size = new System.Drawing.Size(169, 55);
            this.button_SoloTabelle.TabIndex = 11;
            this.button_SoloTabelle.Text = "Solo tabelle";
            this.button_SoloTabelle.UseVisualStyleBackColor = true;
            this.button_SoloTabelle.Click += new System.EventHandler(this.button_SoloTabelle_Click);
            // 
            // button_Tutto
            // 
            this.button_Tutto.Location = new System.Drawing.Point(400, 35);
            this.button_Tutto.Margin = new System.Windows.Forms.Padding(6);
            this.button_Tutto.Name = "button_Tutto";
            this.button_Tutto.Size = new System.Drawing.Size(169, 55);
            this.button_Tutto.TabIndex = 10;
            this.button_Tutto.Text = "Viste e tabelle";
            this.button_Tutto.UseVisualStyleBackColor = true;
            this.button_Tutto.Click += new System.EventHandler(this.button_Tutto_Click);
            // 
            // dataGridView_dettagli
            // 
            this.dataGridView_dettagli.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_dettagli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_dettagli.Location = new System.Drawing.Point(40, 480);
            this.dataGridView_dettagli.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView_dettagli.Name = "dataGridView_dettagli";
            this.dataGridView_dettagli.Size = new System.Drawing.Size(1324, 345);
            this.dataGridView_dettagli.TabIndex = 9;
            // 
            // dataGridView_tabelle
            // 
            this.dataGridView_tabelle.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_tabelle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_tabelle.Location = new System.Drawing.Point(40, 124);
            this.dataGridView_tabelle.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView_tabelle.Name = "dataGridView_tabelle";
            this.dataGridView_tabelle.Size = new System.Drawing.Size(1324, 345);
            this.dataGridView_tabelle.TabIndex = 8;
            // 
            // button_SoloViste
            // 
            this.button_SoloViste.Location = new System.Drawing.Point(40, 35);
            this.button_SoloViste.Margin = new System.Windows.Forms.Padding(6);
            this.button_SoloViste.Name = "button_SoloViste";
            this.button_SoloViste.Size = new System.Drawing.Size(169, 55);
            this.button_SoloViste.TabIndex = 7;
            this.button_SoloViste.Text = "Solo viste";
            this.button_SoloViste.UseVisualStyleBackColor = true;
            this.button_SoloViste.Click += new System.EventHandler(this.button_SoloViste_Click);
            // 
            // TestVari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1788, 937);
            this.Controls.Add(this.button_CreaVista);
            this.Controls.Add(this.button_insRuolo);
            this.Controls.Add(this.button_SoloTabelle);
            this.Controls.Add(this.button_Tutto);
            this.Controls.Add(this.dataGridView_dettagli);
            this.Controls.Add(this.dataGridView_tabelle);
            this.Controls.Add(this.button_SoloViste);
            this.Name = "TestVari";
            this.Text = "TestVari";
            this.Load += new System.EventHandler(this.TestVari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dettagli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tabelle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_CreaVista;
        private System.Windows.Forms.Button button_insRuolo;
        private System.Windows.Forms.Button button_SoloTabelle;
        private System.Windows.Forms.Button button_Tutto;
        private System.Windows.Forms.DataGridView dataGridView_dettagli;
        private System.Windows.Forms.DataGridView dataGridView_tabelle;
        private System.Windows.Forms.Button button_SoloViste;
    }
}