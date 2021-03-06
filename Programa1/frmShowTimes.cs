﻿using System;
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
    public partial class frmShowTimes : Form
    {
        public frmShowTimes(List<Process> Processes)
        {
            InitializeComponent();
            SetTimes(Processes);
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

        private void SetTimes(List<Process> pro)
        {
            DataTable myDataTable = new DataTable();
            myDataTable.Columns.Add("ID");
            myDataTable.Columns.Add("Llegada");
            myDataTable.Columns.Add("Final");
            myDataTable.Columns.Add("Retorno");
            myDataTable.Columns.Add("Respuesta");
            myDataTable.Columns.Add("Espera");
            myDataTable.Columns.Add("Servicio");
            myDataTable.Columns.Add("Restante");
            myDataTable.Columns.Add("Bloqueado");
            myDataTable.Columns.Add("TME");

            //myDataTable.Columns.Add("Tleft");
            //myDataTable.Columns.Add("TME");
            //myDataTable.Columns.Add("TExe");

            foreach (Process p in pro)
            {
                myDataTable.Rows.Add(
                                     p.id, 
                                     p.t_llegada != -1 ? p.t_llegada.ToString() : "",
                                     p.t_finalizacion != -1 ? p.t_finalizacion.ToString() : "", 
                                     p.t_retorno != -1 ? p.t_retorno.ToString() : "",
                                     p.t_respuesta != -1 ? p.t_respuesta.ToString() : "",
                                     p.t_espera != -1 ? p.t_espera.ToString() : "",
                                     p.t_servicio != -1 ? p.t_servicio.ToString() : "",
                                     p.leftTimeAux != -1 ? p.leftTimeAux.ToString() : "",
                                     p.leftTimeAux != 0 ? p.locked.ToString() : "",
                                     p.maxTime
                                     );
            }

            dgvProcessesTimes.DataSource = myDataTable;
            DataGridViewAutoSize(dgvProcessesTimes);
        }
    }
}
