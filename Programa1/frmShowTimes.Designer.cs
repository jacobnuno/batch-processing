namespace Programa1
{
    partial class frmShowTimes
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
            this.dgvProcessesTimes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessesTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProcessesTimes
            // 
            this.dgvProcessesTimes.AllowUserToAddRows = false;
            this.dgvProcessesTimes.AllowUserToDeleteRows = false;
            this.dgvProcessesTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcessesTimes.Location = new System.Drawing.Point(41, 96);
            this.dgvProcessesTimes.Name = "dgvProcessesTimes";
            this.dgvProcessesTimes.ReadOnly = true;
            this.dgvProcessesTimes.RowTemplate.Height = 24;
            this.dgvProcessesTimes.Size = new System.Drawing.Size(1381, 329);
            this.dgvProcessesTimes.TabIndex = 2;
            this.dgvProcessesTimes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProcessesTimes_KeyDown);
            // 
            // frmShowTimes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 450);
            this.Controls.Add(this.dgvProcessesTimes);
            this.Name = "frmShowTimes";
            this.Text = "ShowTimes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessesTimes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProcessesTimes;
    }
}