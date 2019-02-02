namespace Programa1
{
    partial class frmAddProcesses
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
            this.lblDeveloper = new System.Windows.Forms.Label();
            this.txtDeveloper = new System.Windows.Forms.TextBox();
            this.lblNumber1 = new System.Windows.Forms.Label();
            this.lblNumber2 = new System.Windows.Forms.Label();
            this.lblOperator = new System.Windows.Forms.Label();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.inputNumber1 = new System.Windows.Forms.NumericUpDown();
            this.inputNumber2 = new System.Windows.Forms.NumericUpDown();
            this.lblMaxTime = new System.Windows.Forms.Label();
            this.inputMaxTime = new System.Windows.Forms.NumericUpDown();
            this.lblID = new System.Windows.Forms.Label();
            this.inputIDProcess = new System.Windows.Forms.NumericUpDown();
            this.btnAddProcess = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumber1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumber2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputMaxTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputIDProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDeveloper
            // 
            this.lblDeveloper.AutoSize = true;
            this.lblDeveloper.Location = new System.Drawing.Point(12, 62);
            this.lblDeveloper.Name = "lblDeveloper";
            this.lblDeveloper.Size = new System.Drawing.Size(231, 17);
            this.lblDeveloper.TabIndex = 0;
            this.lblDeveloper.Text = "Ingresa el nombre del programador";
            // 
            // txtDeveloper
            // 
            this.txtDeveloper.Location = new System.Drawing.Point(303, 59);
            this.txtDeveloper.Name = "txtDeveloper";
            this.txtDeveloper.Size = new System.Drawing.Size(263, 22);
            this.txtDeveloper.TabIndex = 1;
            // 
            // lblNumber1
            // 
            this.lblNumber1.AutoSize = true;
            this.lblNumber1.Location = new System.Drawing.Point(79, 116);
            this.lblNumber1.Name = "lblNumber1";
            this.lblNumber1.Size = new System.Drawing.Size(70, 17);
            this.lblNumber1.TabIndex = 2;
            this.lblNumber1.Text = "Número 1";
            // 
            // lblNumber2
            // 
            this.lblNumber2.AutoSize = true;
            this.lblNumber2.Location = new System.Drawing.Point(479, 116);
            this.lblNumber2.Name = "lblNumber2";
            this.lblNumber2.Size = new System.Drawing.Size(70, 17);
            this.lblNumber2.TabIndex = 3;
            this.lblNumber2.Text = "Número 2";
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(282, 116);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(74, 17);
            this.lblOperator.TabIndex = 4;
            this.lblOperator.Text = "Operación";
            // 
            // cboOperator
            // 
            this.cboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.Location = new System.Drawing.Point(285, 152);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(70, 24);
            this.cboOperator.TabIndex = 5;
            // 
            // inputNumber1
            // 
            this.inputNumber1.Location = new System.Drawing.Point(82, 153);
            this.inputNumber1.Name = "inputNumber1";
            this.inputNumber1.Size = new System.Drawing.Size(67, 22);
            this.inputNumber1.TabIndex = 6;
            // 
            // inputNumber2
            // 
            this.inputNumber2.Location = new System.Drawing.Point(487, 152);
            this.inputNumber2.Name = "inputNumber2";
            this.inputNumber2.Size = new System.Drawing.Size(61, 22);
            this.inputNumber2.TabIndex = 7;
            this.inputNumber2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMaxTime
            // 
            this.lblMaxTime.AutoSize = true;
            this.lblMaxTime.Location = new System.Drawing.Point(79, 235);
            this.lblMaxTime.Name = "lblMaxTime";
            this.lblMaxTime.Size = new System.Drawing.Size(106, 17);
            this.lblMaxTime.TabIndex = 8;
            this.lblMaxTime.Text = "Tiempo máximo";
            // 
            // inputMaxTime
            // 
            this.inputMaxTime.Location = new System.Drawing.Point(82, 275);
            this.inputMaxTime.Name = "inputMaxTime";
            this.inputMaxTime.Size = new System.Drawing.Size(85, 22);
            this.inputMaxTime.TabIndex = 9;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(268, 235);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(144, 17);
            this.lblID.TabIndex = 10;
            this.lblID.Text = "Número de Programa";
            // 
            // inputIDProcess
            // 
            this.inputIDProcess.Location = new System.Drawing.Point(285, 275);
            this.inputIDProcess.Name = "inputIDProcess";
            this.inputIDProcess.Size = new System.Drawing.Size(85, 22);
            this.inputIDProcess.TabIndex = 11;
            // 
            // btnAddProcess
            // 
            this.btnAddProcess.Location = new System.Drawing.Point(472, 263);
            this.btnAddProcess.Name = "btnAddProcess";
            this.btnAddProcess.Size = new System.Drawing.Size(115, 44);
            this.btnAddProcess.TabIndex = 12;
            this.btnAddProcess.Text = "Agregar";
            this.btnAddProcess.UseVisualStyleBackColor = true;
            this.btnAddProcess.Click += new System.EventHandler(this.btnAddProcess_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(514, 17);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 17);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "label1";
            // 
            // frmAddProcesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 416);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnAddProcess);
            this.Controls.Add(this.inputIDProcess);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.inputMaxTime);
            this.Controls.Add(this.lblMaxTime);
            this.Controls.Add(this.inputNumber2);
            this.Controls.Add(this.inputNumber1);
            this.Controls.Add(this.cboOperator);
            this.Controls.Add(this.lblOperator);
            this.Controls.Add(this.lblNumber2);
            this.Controls.Add(this.lblNumber1);
            this.Controls.Add(this.txtDeveloper);
            this.Controls.Add(this.lblDeveloper);
            this.Name = "frmAddProcesses";
            this.Text = "frmAddProcesses";
            ((System.ComponentModel.ISupportInitialize)(this.inputNumber1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumber2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputMaxTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputIDProcess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.TextBox txtDeveloper;
        private System.Windows.Forms.Label lblNumber1;
        private System.Windows.Forms.Label lblNumber2;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.ComboBox cboOperator;
        private System.Windows.Forms.NumericUpDown inputNumber1;
        private System.Windows.Forms.NumericUpDown inputNumber2;
        private System.Windows.Forms.Label lblMaxTime;
        private System.Windows.Forms.NumericUpDown inputMaxTime;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.NumericUpDown inputIDProcess;
        private System.Windows.Forms.Button btnAddProcess;
        private System.Windows.Forms.Label lblStatus;
    }
}