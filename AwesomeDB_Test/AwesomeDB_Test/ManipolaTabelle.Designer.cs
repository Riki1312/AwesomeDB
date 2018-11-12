namespace AwesomeDB_Test
{
    partial class ManipolaTabelle
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
            this.button_rinominaTab = new System.Windows.Forms.Button();
            this.button_rimuoviTab = new System.Windows.Forms.Button();
            this.button_CreaTabella = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_CreaDb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_rinominaTab
            // 
            this.button_rinominaTab.Location = new System.Drawing.Point(645, 155);
            this.button_rinominaTab.Margin = new System.Windows.Forms.Padding(6);
            this.button_rinominaTab.Name = "button_rinominaTab";
            this.button_rinominaTab.Size = new System.Drawing.Size(235, 59);
            this.button_rinominaTab.TabIndex = 7;
            this.button_rinominaTab.Text = "RinominaTabella";
            this.button_rinominaTab.UseVisualStyleBackColor = true;
            this.button_rinominaTab.Click += new System.EventHandler(this.button_rinominaTab_Click);
            // 
            // button_rimuoviTab
            // 
            this.button_rimuoviTab.Location = new System.Drawing.Point(398, 155);
            this.button_rimuoviTab.Margin = new System.Windows.Forms.Padding(6);
            this.button_rimuoviTab.Name = "button_rimuoviTab";
            this.button_rimuoviTab.Size = new System.Drawing.Size(235, 59);
            this.button_rimuoviTab.TabIndex = 6;
            this.button_rimuoviTab.Text = "Rimuovi Tabella";
            this.button_rimuoviTab.UseVisualStyleBackColor = true;
            this.button_rimuoviTab.Click += new System.EventHandler(this.button_rimuoviTab_Click);
            // 
            // button_CreaTabella
            // 
            this.button_CreaTabella.Location = new System.Drawing.Point(151, 155);
            this.button_CreaTabella.Margin = new System.Windows.Forms.Padding(6);
            this.button_CreaTabella.Name = "button_CreaTabella";
            this.button_CreaTabella.Size = new System.Drawing.Size(235, 59);
            this.button_CreaTabella.TabIndex = 5;
            this.button_CreaTabella.Text = "CreaTabella";
            this.button_CreaTabella.UseVisualStyleBackColor = true;
            this.button_CreaTabella.Click += new System.EventHandler(this.button_CreaTabella_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 292);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 31;
            this.dataGridView1.Size = new System.Drawing.Size(1025, 413);
            this.dataGridView1.TabIndex = 8;
            // 
            // button_CreaDb
            // 
            this.button_CreaDb.BackColor = System.Drawing.Color.White;
            this.button_CreaDb.Location = new System.Drawing.Point(151, 84);
            this.button_CreaDb.Margin = new System.Windows.Forms.Padding(6);
            this.button_CreaDb.Name = "button_CreaDb";
            this.button_CreaDb.Size = new System.Drawing.Size(235, 59);
            this.button_CreaDb.TabIndex = 9;
            this.button_CreaDb.Text = "CreaDB";
            this.button_CreaDb.UseVisualStyleBackColor = false;
            this.button_CreaDb.Click += new System.EventHandler(this.button_CreaDb_Click);
            // 
            // ManipolaTabelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 733);
            this.Controls.Add(this.button_CreaDb);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_rinominaTab);
            this.Controls.Add(this.button_rimuoviTab);
            this.Controls.Add(this.button_CreaTabella);
            this.Name = "ManipolaTabelle";
            this.Text = "ManipolaTabelle";
            this.Load += new System.EventHandler(this.ManipolaTabelle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_rinominaTab;
        private System.Windows.Forms.Button button_rimuoviTab;
        private System.Windows.Forms.Button button_CreaTabella;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_CreaDb;
    }
}