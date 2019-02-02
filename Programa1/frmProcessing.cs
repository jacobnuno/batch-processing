using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa1
{
    public partial class frmProcessing : Form
    {
        Queue<Batch> batches = new Queue<Batch>();
        Batch actualBatch = new Batch();
        List<Process> ConcludedProcesses = new List<Process>();
        Process actualProcess;
        int leftTime = 0;
        int executionTime = 0;
        int counter = 0;
        int noBatch = 1;

        public frmProcessing(Queue<Batch> batches)
        {
            this.batches = batches;
            InitializeComponent();
            timer.Start();
            StarProcessing();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(leftTime > 0)
            {
                lblCounter.Text = (++counter).ToString();
                lblLeftTime.Text = (--leftTime).ToString();
                lblExecutionTime.Text = (++executionTime).ToString();
            } else if (actualBatch.Processes.Count > 0)
            {
                
                ConcludedProcesses.Add(actualProcess);

                actualProcess = actualBatch.Processes.Dequeue();
                actualProcess.noBatch = noBatch;
                SetActualBatch(actualBatch);
                SetActualProcess(actualProcess);

                SetConcludedProcesses(ConcludedProcesses);
                
            } else if(batches.Count > 0) 
            {

                actualBatch = batches.Dequeue();
                noBatch++;
                llbPendingBatches.Text = batches.Count.ToString();
            } else
            {
                actualProcess.noBatch = noBatch;
                ConcludedProcesses.Add(actualProcess);
                SetConcludedProcesses(ConcludedProcesses);
                llbPendingBatches.Text = "0";
                timer.Stop();
                MessageBox.Show("Se han terminado todos los procesos", "Concluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            System.Threading.Thread.Sleep(1000);
        }

        public void StarProcessing()
        {
            actualBatch = batches.Dequeue();
            actualProcess = actualBatch.Processes.Dequeue();
            actualProcess.noBatch = noBatch;
            SetActualBatch(actualBatch);
            executionTime = actualProcess.maxTime;
            leftTime = actualProcess.maxTime;
            SetActualProcess(actualProcess);
            llbPendingBatches.Text = batches.Count.ToString();
        }

        public void SetActualProcess(Process p)
        {
            lblProcessId.Text = p.id.ToString();
            lblNameDeveloper.Text = p.nameDeveloper;
            lblOperator.Text = p.myOperator;
            lblMaxTime.Text = p.maxTime.ToString();

            lblExecutionTime.Text = p.maxTime.ToString();
            leftTime = p.maxTime;
            executionTime = 0;
        }

        private void SetActualBatch(Batch l)
        {
            DataTable myDataTable = new DataTable();
            myDataTable.Columns.Add("Nombre");
            myDataTable.Columns.Add("TME");

            foreach (Process p in l.Processes)
            {
                myDataTable.Rows.Add(p.nameDeveloper, p.maxTime);
            }

            dgvBatchExecuting.DataSource = myDataTable;
        }

        private void SetConcludedProcesses(List<Process> pro)
        {
            DataTable myDataTable = new DataTable();
            myDataTable.Columns.Add("ID");
            myDataTable.Columns.Add("Operación");
            myDataTable.Columns.Add("Resultado");
            myDataTable.Columns.Add("No. Lote");

            foreach (Process p in pro)
            {
                myDataTable.Rows.Add(p.id, p.operation, p.result, p.noBatch);
            }

            dgvConcluded.DataSource = myDataTable;
        }

        
    }
}
