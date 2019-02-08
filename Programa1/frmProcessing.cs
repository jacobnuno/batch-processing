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
        int counter = 0;
        int noBatch = 1;
        bool isPaused = false;

        public frmProcessing(Queue<Batch> batches)
        {
            this.batches = batches;
            InitializeComponent();
            timer.Start();
            StarProcessing();
            this.Focus();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (actualProcess.leftTime > 0)
            {
                lblCounter.Text = (++counter).ToString();
                lblLeftTime.Text = (--actualProcess.leftTime).ToString();
                lblExecutionTime.Text = (++actualProcess.executionTime).ToString();
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
            SetActualProcess(actualProcess);
            llbPendingBatches.Text = batches.Count.ToString();
        }

        public void SetActualProcess(Process p)
        {
            lblProcessId.Text = p.id.ToString();
            lblOperator.Text = p.operation;
            lblMaxTime.Text = p.maxTime.ToString();

            lblExecutionTime.Text = p.executionTime.ToString();
        }

        private void SetActualBatch(Batch l)
        {
            /* 
            tiempo de llegada
            tiempo de finalización
            tiempo de servicio = tr - te
            tiempo de espera = tr - ts
            tiempo de retorno = tf - tllegada
            tiempo de respuesta = tiempo de llegada - tiempo actual
            */
            DataTable myDataTable = new DataTable();
            myDataTable.Columns.Add("ID");
            myDataTable.Columns.Add("TME");
            myDataTable.Columns.Add("TT");
            myDataTable.Columns.Add("TR");

            foreach (Process p in l.Processes)
            {
                myDataTable.Rows.Add(p.id, p.maxTime, p.executionTime, p.leftTime);
            }

            dgvBatchExecuting.DataSource = myDataTable;
            DataGridViewAutoSize(dgvBatchExecuting);
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
            DataGridViewAutoSize(dgvConcluded);
        }

        private void DataGridViewAutoSize(DataGridView grd)
        {
            //set autosize mode
            grd.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grd.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grd.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //datagrid has calculated it's widths so we can store them
            for (int i = 0; i <= grd.Columns.Count - 1; i++)
            {
                //store autosized widths
                int colw = grd.Columns[i].Width;
                //remove autosizing
                grd.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //set width to calculated by autosize
                grd.Columns[i].Width = colw;
            }
        }

        private void frmProcessing_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyValue)
            {
                case (int)Keys.I:
                    if(isPaused == false)
                    {
                        Batch myBatch = new Batch();
                        myBatch = actualBatch;
                        actualBatch.Processes.Enqueue(actualProcess);
                        if (myBatch.Processes.Count > 0)
                        {
                            actualProcess = myBatch.Processes.Dequeue();
                            SetActualBatch(myBatch);
                        }
                        else
                        {
                            actualProcess = actualBatch.Processes.Dequeue();
                            SetActualBatch(actualBatch);
                        }
                        SetActualProcess(actualProcess);
                    }
                    break;

                case (int)Keys.E:
                    if (isPaused == false)
                    {
                        actualProcess.result = "Error";
                        actualProcess.leftTime = 0;
                    } 
                    break;

                case (int)Keys.P:
                    if(isPaused == false)
                    {
                        timer.Stop();
                        isPaused = true;
                    }
                    break;

                case (int)Keys.C:
                    if(isPaused)
                    {
                        timer.Start();
                        isPaused = false;
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
