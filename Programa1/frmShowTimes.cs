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
            myDataTable.Columns.Add("TL");
            myDataTable.Columns.Add("TF");
            myDataTable.Columns.Add("TRet");
            myDataTable.Columns.Add("TRes");
            myDataTable.Columns.Add("TE");
            myDataTable.Columns.Add("TS");

            foreach (Process p in pro)
            {
                myDataTable.Rows.Add(p.id, p.t_llegada, p.t_finalizacion, p.t_retorno, p.t_respuesta, p.t_espera, p.t_servicio);
            }

            dgvProcessesTimes.DataSource = myDataTable;
            DataGridViewAutoSize(dgvProcessesTimes);
        }
    }
}
