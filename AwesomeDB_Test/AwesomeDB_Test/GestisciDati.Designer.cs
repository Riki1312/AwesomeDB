namespace AwesomeDB_Test
{
    partial class GestisciDati
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_update = new System.Windows.Forms.Button();
            this.button_delite = new System.Windows.Forms.Button();
            this.button_Alldati = new System.Windows.Forms.Button();
            this.button_AddData = new System.Windows.Forms.Button();
            this.button_Ricarica = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(56, 228);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 31;
            this.dataGridView1.Size = new System.Drawing.Size(1025, 413);
            this.dataGridView1.TabIndex = 12;
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(797, 113);
            this.button_update.Margin = new System.Windows.Forms.Padding(6);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(235, 59);
            this.button_update.TabIndex = 16;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_delite
            // 
            this.button_delite.Location = new System.Drawing.Point(550, 113);
            this.button_delite.Margin = new System.Windows.Forms.Padding(6);
            this.button_delite.Name = "button_delite";
            this.button_delite.Size = new System.Drawing.Size(235, 59);
            this.button_delite.TabIndex = 15;
            this.button_delite.Text = "Delite";
            this.button_delite.UseVisualStyleBackColor = true;
            this.button_delite.Click += new System.EventHandler(this.button_delite_Click);
            // 
            // button_Alldati
            // 
            this.button_Alldati.Location = new System.Drawing.Point(303, 113);
            this.button_Alldati.Margin = new System.Windows.Forms.Padding(6);
            this.button_Alldati.Name = "button_Alldati";
            this.button_Alldati.Size = new System.Drawing.Size(235, 59);
            this.button_Alldati.TabIndex = 14;
            this.button_Alldati.Text = "All Dati";
            this.button_Alldati.UseVisualStyleBackColor = true;
            this.button_Alldati.Click += new System.EventHandler(this.button_Alldati_Click);
            // 
            // button_AddData
            // 
            this.button_AddData.Location = new System.Drawing.Point(56, 113);
            this.button_AddData.Margin = new System.Windows.Forms.Padding(6);
            this.button_AddData.Name = "button_AddData";
            this.button_AddData.Size = new System.Drawing.Size(235, 59);
            this.button_AddData.TabIndex = 13;
            this.button_AddData.Text = "Aggiungi Dati";
            this.button_AddData.UseVisualStyleBackColor = true;
            this.button_AddData.Click += new System.EventHandler(this.button_AddData_Click);
            // 
            // button_Ricarica
            // 
            this.button_Ricarica.BackColor = System.Drawing.Color.White;
            this.button_Ricarica.Location = new System.Drawing.Point(56, 650);
            this.button_Ricarica.Margin = new System.Windows.Forms.Padding(6);
            this.button_Ricarica.Name = "button_Ricarica";
            this.button_Ricarica.Size = new System.Drawing.Size(1025, 48);
            this.button_Ricarica.TabIndex = 17;
            this.button_Ricarica.Text = "Ricarica";
            this.button_Ricarica.UseVisualStyleBackColor = false;
            this.button_Ricarica.Click += new System.EventHandler(this.button_Ricarica_Click);
            // 
            // GestisciDati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 736);
            this.Controls.Add(this.button_Ricarica);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button_delite);
            this.Controls.Add(this.button_Alldati);
            this.Controls.Add(this.button_AddData);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GestisciDati";
            this.Text = "GestisciDati";
            this.Load += new System.EventHandler(this.GestisciDati_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_delite;
        private System.Windows.Forms.Button button_Alldati;
        private System.Windows.Forms.Button button_AddData;
        private System.Windows.Forms.Button button_Ricarica;
    }
}