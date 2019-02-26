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
        //Queue<Batch> batches = new Queue<Batch>();
        Queue<Process> allProcesses = new Queue<Process>();
        Queue<Process> readyProcesses = new Queue<Process>();
        List<Process> lockedProcesses = new List<Process>();
        // Batch actualBatch = new Batch();
        List<Process> ConcludedProcesses = new List<Process>();
        Process actualProcess;
        int counter = 0;
        //int noBatch = 1;
        bool isPaused = false;

        public frmProcessing(Queue<Process> Processes)
        {
            this.allProcesses = Processes;
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
                SetLockedProcesses();
                lblLeftTime.Text = (--actualProcess.leftTime).ToString();
                lblExecutionTime.Text = (++actualProcess.executionTime).ToString();
            } else if (allProcesses.Count > 0)
            {

                actualProcess.t_finalizacion = counter; // add t_fin to actual process
                ConcludedProcesses.Add(actualProcess);
                Process newProcess = allProcesses.Dequeue();
                newProcess.t_llegada = counter;
                readyProcesses.Enqueue(newProcess);
                llbPendingBatches.Text = allProcesses.Count.ToString();
                actualProcess = readyProcesses.Dequeue();
                SetReadyProcesses(readyProcesses);
                SetActualProcess(actualProcess);

                SetConcludedProcesses(ConcludedProcesses);

            } else if(readyProcesses.Count > 0) 
            {
                /*
                actualBatch = batches.Dequeue();
                noBatch++;
                llbPendingBatches.Text = batches.Count.ToString(); */

                actualProcess.t_finalizacion = counter; // add t_fin to actual process
                ConcludedProcesses.Add(actualProcess);
                SetConcludedProcesses(ConcludedProcesses);
                actualProcess = readyProcesses.Dequeue();
                SetActualProcess(actualProcess);
                SetReadyProcesses(readyProcesses);
            }
            else
            {
                //actualProcess.noBatch = noBatch;
                actualProcess.t_finalizacion = counter; // add t_fin to actual process
                ConcludedProcesses.Add(actualProcess);
                SetConcludedProcesses(ConcludedProcesses);
                llbPendingBatches.Text = "0";
                timer.Stop();
                CalculateTimes();
                //MessageBox.Show("Se han terminado todos los procesos", "Concluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            System.Threading.Thread.Sleep(1000);
        }

        public void StarProcessing()
        {
            //actualBatch = batches.Dequeue();
            actualProcess = allProcesses.Dequeue();
            //actualProcess.noBatch = noBatch;
            //SetActualBatch(actualBatch);
            SetActualProcess(actualProcess);
            if(allProcesses.Count > 1)
            {
                readyProcesses.Enqueue(allProcesses.Dequeue()); // second process ready to be execute
                readyProcesses.Enqueue(allProcesses.Dequeue()); // third process ready to be execute
                SetReadyProcesses(readyProcesses);
            }
            
            llbPendingBatches.Text = allProcesses.Count.ToString();
        }

        public void SetActualProcess(Process p)
        {
            lblProcessId.Text = p.id.ToString();
            lblOperator.Text = p.operation;
            lblMaxTime.Text = p.maxTime.ToString();

            lblExecutionTime.Text = p.executionTime.ToString();
        }

        private void SetReadyProcesses(Queue<Process> processes)
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

            foreach (Process p in processes)
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

            foreach (Process p in pro)
            {
                myDataTable.Rows.Add(p.id, p.operation, p.result);
            }

            dgvConcluded.DataSource = myDataTable;
            DataGridViewAutoSize(dgvConcluded);
        }

        private void CalculateTimes()
        {
            foreach (Process p in ConcludedProcesses)
            {
                p.t_retorno = p.t_finalizacion - p.t_llegada;
            }
            frmShowTimes process = new frmShowTimes(ConcludedProcesses);
            this.Hide();
            process.ShowDialog();
        }

        private void SetLockedProcesses()
        {
            DataTable myDataTable = new DataTable();
            myDataTable.Columns.Add("ID");
            myDataTable.Columns.Add("TRB");
            
            if(lockedProcesses.Count > 0)
            {
                foreach (Process p in lockedProcesses)
                {
                    if (++p.locked == 10)
                    {
                        p.locked = 0;
                        readyProcesses.Enqueue(p);
                        lockedProcesses.Remove(p);
                    }
                }
            }
            

            foreach (Process p in lockedProcesses)
            {
                myDataTable.Rows.Add(p.id, p.locked);
            }

            dgvLockedProcesses.DataSource = myDataTable;
            //DataGridViewAutoSize(dgvLockedProcesses);
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
                    { /*
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
                        } */
                        lockedProcesses.Add(actualProcess);
                        SetLockedProcesses();
                        actualProcess = readyProcesses.Dequeue();
                        SetActualProcess(actualProcess);
                        SetReadyProcesses(readyProcesses);
                        //timer_Tick(null, null);
                    }
                    break;

                case (int)Keys.E:
                    if (isPaused == false)
                    {
                        actualProcess.result = "Error";
                        actualProcess.leftTime = 0;
                        //timer.Start();
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
