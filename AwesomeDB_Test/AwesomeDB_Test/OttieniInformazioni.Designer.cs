namespace AwesomeDB_Test
{
    partial class OttieniInformazioni
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
            this.button_cTipe = new System.Windows.Forms.Button();
            this.button_cName = new System.Windows.Forms.Button();
            this.button_tName = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(41, 318);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 31;
            this.dataGridView1.Size = new System.Drawing.Size(1025, 413);
            this.dataGridView1.TabIndex = 10;
            // 
            // button_cTipe
            // 
            this.button_cTipe.Location = new System.Drawing.Point(41, 198);
            this.button_cTipe.Margin = new System.Windows.Forms.Padding(6);
            this.button_cTipe.Name = "button_cTipe";
            this.button_cTipe.Size = new System.Drawing.Size(235, 59);
            this.button_cTipe.TabIndex = 13;
            this.button_cTipe.Text = "Tipi Colonne";
            this.button_cTipe.UseVisualStyleBackColor = true;
            this.button_cTipe.Click += new System.EventHandler(this.button_cTipe_Click);
            // 
            // button_cName
            // 
            this.button_cName.Location = new System.Drawing.Point(41, 127);
            this.button_cName.Margin = new System.Windows.Forms.Padding(6);
            this.button_cName.Name = "button_cName";
            this.button_cName.Size = new System.Drawing.Size(235, 59);
            this.button_cName.TabIndex = 12;
            this.button_cName.Text = "Nomi Colonne";
            this.button_cName.UseVisualStyleBackColor = true;
            this.button_cName.Click += new System.EventHandler(this.button_cName_Click);
            // 
            // button_tName
            // 
            this.button_tName.Location = new System.Drawing.Point(41, 56);
            this.button_tName.Margin = new System.Windows.Forms.Padding(6);
            this.button_tName.Name = "button_tName";
            this.button_tName.Size = new System.Drawing.Size(235, 59);
            this.button_tName.TabIndex = 11;
            this.button_tName.Text = "Nomi Tabelle";
            this.button_tName.UseVisualStyleBackColor = true;
            this.button_tName.Click += new System.EventHandler(this.button_tName_Click);
            // 
            // OttieniInformazioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 775);
            this.Controls.Add(this.button_cTipe);
            this.Controls.Add(this.button_cName);
            this.Controls.Add(this.button_tName);
            this.Controls.Add(this.dataGridView1);
            this.Name = "OttieniInformazioni";
            this.Text = "OttieniInformazioni";
            this.Load += new System.EventHandler(this.OttieniInformazioni_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_cTipe;
        private System.Windows.Forms.Button button_cName;
        private System.Windows.Forms.Button button_tName;
    }
}