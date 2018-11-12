namespace AwesomeDB_Test
{
    partial class ManipolaColonne
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
            this.button_cColon = new System.Windows.Forms.Button();
            this.button_rimColon = new System.Windows.Forms.Button();
            this.button_addColon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 347);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 31;
            this.dataGridView1.Size = new System.Drawing.Size(1025, 413);
            this.dataGridView1.TabIndex = 9;
            // 
            // button_cColon
            // 
            this.button_cColon.Location = new System.Drawing.Point(69, 213);
            this.button_cColon.Margin = new System.Windows.Forms.Padding(6);
            this.button_cColon.Name = "button_cColon";
            this.button_cColon.Size = new System.Drawing.Size(235, 59);
            this.button_cColon.TabIndex = 16;
            this.button_cColon.Text = "Cambia Colonna";
            this.button_cColon.UseVisualStyleBackColor = true;
            this.button_cColon.Click += new System.EventHandler(this.button_cColon_Click);
            // 
            // button_rimColon
            // 
            this.button_rimColon.Location = new System.Drawing.Point(69, 142);
            this.button_rimColon.Margin = new System.Windows.Forms.Padding(6);
            this.button_rimColon.Name = "button_rimColon";
            this.button_rimColon.Size = new System.Drawing.Size(235, 59);
            this.button_rimColon.TabIndex = 15;
            this.button_rimColon.Text = "Rim Colonna";
            this.button_rimColon.UseVisualStyleBackColor = true;
            this.button_rimColon.Click += new System.EventHandler(this.button_rimColon_Click);
            // 
            // button_addColon
            // 
            this.button_addColon.Location = new System.Drawing.Point(69, 71);
            this.button_addColon.Margin = new System.Windows.Forms.Padding(6);
            this.button_addColon.Name = "button_addColon";
            this.button_addColon.Size = new System.Drawing.Size(235, 59);
            this.button_addColon.TabIndex = 14;
            this.button_addColon.Text = "Add Colonna";
            this.button_addColon.UseVisualStyleBackColor = true;
            this.button_addColon.Click += new System.EventHandler(this.button_addColon_Click);
            // 
            // ManipolaColonne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 793);
            this.Controls.Add(this.button_cColon);
            this.Controls.Add(this.button_rimColon);
            this.Controls.Add(this.button_addColon);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ManipolaColonne";
            this.Text = "ManipolaColonne";
            this.Load += new System.EventHandler(this.ManipolaColonne_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_cColon;
        private System.Windows.Forms.Button button_rimColon;
        private System.Windows.Forms.Button button_addColon;
    }
}