namespace Programa1
{
    partial class frmProcessing
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
            this.components = new System.ComponentModel.Container();
            this.dgvConcluded = new System.Windows.Forms.DataGridView();
            this.dgvBatchExecuting = new System.Windows.Forms.DataGridView();
            this.llbPending = new System.Windows.Forms.Label();
            this.llbPendingBatches = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNameDeveloper = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblOperator = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMaxTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblProcessId = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblExecutionTime = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblLeftTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblCounter = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcluded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatchExecuting)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConcluded
            // 
            this.dgvConcluded.AllowUserToAddRows = false;
            this.dgvConcluded.AllowUserToDeleteRows = false;
            this.dgvConcluded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConcluded.Location = new System.Drawing.Point(789, 173);
            this.dgvConcluded.Name = "dgvConcluded";
            this.dgvConcluded.ReadOnly = true;
            this.dgvConcluded.RowTemplate.Height = 24;
            this.dgvConcluded.Size = new System.Drawing.Size(514, 264);
            this.dgvConcluded.TabIndex = 0;
            this.dgvConcluded.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProcessing_KeyDown);
            // 
            // dgvBatchExecuting
            // 
            this.dgvBatchExecuting.AllowUserToAddRows = false;
            this.dgvBatchExecuting.AllowUserToDeleteRows = false;
            this.dgvBatchExecuting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBatchExecuting.Location = new System.Drawing.Point(14, 173);
            this.dgvBatchExecuting.Name = "dgvBatchExecuting";
            this.dgvBatchExecuting.ReadOnly = true;
            this.dgvBatchExecuting.RowTemplate.Height = 24;
            this.dgvBatchExecuting.Size = new System.Drawing.Size(443, 259);
            this.dgvBatchExecuting.TabIndex = 1;
            this.dgvBatchExecuting.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProcessing_KeyDown);
            // 
            // llbPending
            // 
            this.llbPending.AutoSize = true;
            this.llbPending.Location = new System.Drawing.Point(36, 22);
            this.llbPending.Name = "llbPending";
            this.llbPending.Size = new System.Drawing.Size(121, 17);
            this.llbPending.TabIndex = 2;
            this.llbPending.Text = "Lotes pendientes:";
            // 
            // llbPendingBatches
            // 
            this.llbPendingBatches.AutoSize = true;
            this.llbPendingBatches.Location = new System.Drawing.Point(172, 22);
            this.llbPendingBatches.Name = "llbPendingBatches";
            this.llbPendingBatches.Size = new System.Drawing.Size(16, 17);
            this.llbPendingBatches.TabIndex = 3;
            this.llbPendingBatches.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lote en Ejecución";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(978, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Procesos Terminados";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(555, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Proceso en Ejecución";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(492, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nombre:";
            // 
            // lblNameDeveloper
            // 
            this.lblNameDeveloper.AutoSize = true;
            this.lblNameDeveloper.Location = new System.Drawing.Point(670, 219);
            this.lblNameDeveloper.Name = "lblNameDeveloper";
            this.lblNameDeveloper.Size = new System.Drawing.Size(30, 17);
            this.lblNameDeveloper.TabIndex = 8;
            this.lblNameDeveloper.Text = "null";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(492, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Operación:";
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(670, 254);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(30, 17);
            this.lblOperator.TabIndex = 10;
            this.lblOperator.Text = "null";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(492, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tiempo Máximo Estimado:";
            // 
            // lblMaxTime
            // 
            this.lblMaxTime.AutoSize = true;
            this.lblMaxTime.Location = new System.Drawing.Point(670, 288);
            this.lblMaxTime.Name = "lblMaxTime";
            this.lblMaxTime.Size = new System.Drawing.Size(30, 17);
            this.lblMaxTime.TabIndex = 12;
            this.lblMaxTime.Text = "null";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(492, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Número del programa:";
            // 
            // lblProcessId
            // 
            this.lblProcessId.AutoSize = true;
            this.lblProcessId.Location = new System.Drawing.Point(670, 184);
            this.lblProcessId.Name = "lblProcessId";
            this.lblProcessId.Size = new System.Drawing.Size(30, 17);
            this.lblProcessId.TabIndex = 14;
            this.lblProcessId.Text = "null";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(492, 339);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(223, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tiempo transcurrido en ejecución:";
            // 
            // lblExecutionTime
            // 
            this.lblExecutionTime.AutoSize = true;
            this.lblExecutionTime.Location = new System.Drawing.Point(731, 339);
            this.lblExecutionTime.Name = "lblExecutionTime";
            this.lblExecutionTime.Size = new System.Drawing.Size(30, 17);
            this.lblExecutionTime.TabIndex = 16;
            this.lblExecutionTime.Text = "null";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(492, 368);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(195, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Tiempo restante por ejecutar:";
            // 
            // lblLeftTime
            // 
            this.lblLeftTime.AutoSize = true;
            this.lblLeftTime.Location = new System.Drawing.Point(731, 368);
            this.lblLeftTime.Name = "lblLeftTime";
            this.lblLeftTime.Size = new System.Drawing.Size(30, 17);
            this.lblLeftTime.TabIndex = 18;
            this.lblLeftTime.Text = "null";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(898, 47);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(30, 17);
            this.lblCounter.TabIndex = 19;
            this.lblCounter.Text = "null";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(802, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Tiempo:";
            // 
            // frmProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 481);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.lblLeftTime);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblExecutionTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblProcessId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblMaxTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblOperator);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblNameDeveloper);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.llbPendingBatches);
            this.Controls.Add(this.llbPending);
            this.Controls.Add(this.dgvBatchExecuting);
            this.Controls.Add(this.dgvConcluded);
            this.Name = "frmProcessing";
            this.Text = "frmProcessing";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProcessing_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcluded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatchExecuting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConcluded;
        private System.Windows.Forms.DataGridView dgvBatchExecuting;
        private System.Windows.Forms.Label llbPending;
        private System.Windows.Forms.Label llbPendingBatches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNameDeveloper;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMaxTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblProcessId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblExecutionTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblLeftTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Label label10;
    }
}