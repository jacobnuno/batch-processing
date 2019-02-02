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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int processNumber = Convert.ToInt32(inputProcess.Value);
            if (processNumber <= 0)
            {
                MessageBox.Show("Número de Procesos Inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmAddProcesses Add = new frmAddProcesses(processNumber);
            this.Hide();
            Add.ShowDialog();
        }
    }
}
