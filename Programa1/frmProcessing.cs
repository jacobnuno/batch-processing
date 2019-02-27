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
        Queue<Process> allProcesses = new Queue<Process>();
        Queue<Process> readyProcesses = new Queue<Process>();
        Queue<Process> lockedProcesses = new Queue<Process>();
        List<Process> ConcludedProcesses = new List<Process>();
        Process actualProcess;
        int counter = 0;
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
            if (actualProcess == null)
            {
                lblCounter.Text = (++counter).ToString();
                SetLockedProcesses();
                if (readyProcesses.Count > 0)
                {
                    actualProcess = readyProcesses.Dequeue();
                    SetActualProcess(actualProcess);
                    if (actualProcess.t_respuesta == -1)
                    {
                        actualProcess.t_respuesta = counter - actualProcess.t_llegada;
                    }
                }
            }
            else if (actualProcess.leftTime > 0)
            {
                lblCounter.Text = (++counter).ToString();
                SetLockedProcesses();
                lblLeftTime.Text = (--actualProcess.leftTime).ToString();
                actualProcess.leftTimeAux = actualProcess.leftTime;
                lblExecutionTime.Text = (++actualProcess.executionTime).ToString();
            }
            else if (allProcesses.Count > 0)
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
                if (actualProcess.t_respuesta == -1)
                {
                    actualProcess.t_respuesta = counter - actualProcess.t_llegada;
                }

                SetConcludedProcesses(ConcludedProcesses);

            }
            else if (readyProcesses.Count > 0)
            {
                actualProcess.t_finalizacion = counter; // add t_fin to actual process
                ConcludedProcesses.Add(actualProcess);
                SetConcludedProcesses(ConcludedProcesses);
                actualProcess = readyProcesses.Dequeue();
                SetActualProcess(actualProcess);
                if (actualProcess.t_respuesta == -1)
                {
                    actualProcess.t_respuesta = counter - actualProcess.t_llegada;
                }
                SetReadyProcesses(readyProcesses);
            }
            else if (lockedProcesses.Count > 0)
            {
                actualProcess = null;
                SetActualProcess(actualProcess);
            }
            else
            {
                actualProcess.t_finalizacion = counter; // add t_fin to actual process
                ConcludedProcesses.Add(actualProcess);
                SetConcludedProcesses(ConcludedProcesses);
                llbPendingBatches.Text = "0";
                timer.Stop();
                CalculateTimes();
            }
        }

        public void StarProcessing()
        {
            actualProcess = allProcesses.Dequeue();
            SetActualProcess(actualProcess);
            actualProcess.t_respuesta = 0;
            if (allProcesses.Count > 1)
            {
                readyProcesses.Enqueue(allProcesses.Dequeue()); // second process ready to be execute
                readyProcesses.Enqueue(allProcesses.Dequeue()); // third process ready to be execute
                SetReadyProcesses(readyProcesses);
            }
            
            llbPendingBatches.Text = allProcesses.Count.ToString();
        }

        public void SetActualProcess(Process p)
        {
            if(p != null)
            {
                lblProcessId.Text = p.id.ToString();
                lblOperator.Text = p.operation;
                lblMaxTime.Text = p.maxTime.ToString();
                lblExecutionTime.Text = p.executionTime.ToString();
            } else
            {
                lblProcessId.Text = "null";
                lblOperator.Text = "null";
                lblMaxTime.Text = "null";
                lblLeftTime.Text = "null";
                lblExecutionTime.Text = "null";
            }
        }

        private void SetReadyProcesses(Queue<Process> processes)
        {
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
            /* 
            tiempo de llegada
            tiempo de finalización
            tiempo de servicio = tr - te
            tiempo de espera = tr - ts
            tiempo de retorno = tf - tllegada
            tiempo de respuesta = tiempo de llegada - tiempo actual
            */
            foreach (Process p in ConcludedProcesses)
            {
                p.t_retorno = p.t_finalizacion - p.t_llegada;
                p.t_servicio = p.executionTime;
                p.t_espera = p.t_retorno - p.t_servicio;
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
                    ++p.locked;
                }
                if(lockedProcesses.First().locked == 10)
                {
                    readyProcesses.Enqueue(lockedProcesses.Dequeue());
                    SetReadyProcesses(readyProcesses);
                }
            }
            

            foreach (Process p in lockedProcesses)
            {
                myDataTable.Rows.Add(p.id, p.locked);
            }

            dgvLockedProcesses.DataSource = myDataTable;
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
                        if(actualProcess != null)
                        {
                            actualProcess.locked = 0;
                            lockedProcesses.Enqueue(actualProcess);
                            SetLockedProcesses();
                            if(readyProcesses.Count > 0)
                            {
                                actualProcess = readyProcesses.Dequeue();
                                SetActualProcess(actualProcess);
                                if (actualProcess.t_respuesta == -1)
                                {
                                    actualProcess.t_respuesta = counter - actualProcess.t_llegada;
                                }
                                SetReadyProcesses(readyProcesses);
                            } else
                            {
                                actualProcess = null;
                                SetActualProcess(actualProcess);
                            }
                            
                        }
                    }
                    break;

                case (int)Keys.E:
                    if (isPaused == false)
                    {
                        if(actualProcess != null)
                        {
                            actualProcess.result = "Error";
                            actualProcess.leftTime = 0;
                        }
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
