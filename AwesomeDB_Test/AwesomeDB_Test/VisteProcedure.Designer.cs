namespace AwesomeDB_Test
{
    partial class VisteProcedure
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
            this.button_remView = new System.Windows.Forms.Button();
            this.button_addView = new System.Windows.Forms.Button();
            this.button_procedure = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(81, 430);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 31;
            this.dataGridView1.Size = new System.Drawing.Size(1025, 413);
            this.dataGridView1.TabIndex = 11;
            // 
            // button_remView
            // 
            this.button_remView.Location = new System.Drawing.Point(81, 262);
            this.button_remView.Margin = new System.Windows.Forms.Padding(6);
            this.button_remView.Name = "button_remView";
            this.button_remView.Size = new System.Drawing.Size(235, 59);
            this.button_remView.TabIndex = 16;
            this.button_remView.Text = "Rimuovi View";
            this.button_remView.UseVisualStyleBackColor = true;
            this.button_remView.Click += new System.EventHandler(this.button_remView_Click);
            // 
            // button_addView
            // 
            this.button_addView.Location = new System.Drawing.Point(81, 191);
            this.button_addView.Margin = new System.Windows.Forms.Padding(6);
            this.button_addView.Name = "button_addView";
            this.button_addView.Size = new System.Drawing.Size(235, 59);
            this.button_addView.TabIndex = 15;
            this.button_addView.Text = "Crea View";
            this.button_addView.UseVisualStyleBackColor = true;
            this.button_addView.Click += new System.EventHandler(this.button_addView_Click);
            // 
            // button_procedure
            // 
            this.button_procedure.Location = new System.Drawing.Point(81, 120);
            this.button_procedure.Margin = new System.Windows.Forms.Padding(6);
            this.button_procedure.Name = "button_procedure";
            this.button_procedure.Size = new System.Drawing.Size(235, 59);
            this.button_procedure.TabIndex = 14;
            this.button_procedure.Text = "Richiama Procedura";
            this.button_procedure.UseVisualStyleBackColor = true;
            this.button_procedure.Click += new System.EventHandler(this.button_procedure_Click);
            // 
            // VisteProcedure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 897);
            this.Controls.Add(this.button_remView);
            this.Controls.Add(this.button_addView);
            this.Controls.Add(this.button_procedure);
            this.Controls.Add(this.dataGridView1);
            this.Name = "VisteProcedure";
            this.Text = "VisteProcedure";
            this.Load += new System.EventHandler(this.VisteProcedure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_remView;
        private System.Windows.Forms.Button button_addView;
        private System.Windows.Forms.Button button_procedure;
    }
}