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
    public partial class frmAddProcesses : Form
    {
        int totalProcesses = 0;
        int cont = 0;
        Queue<Process> Processess = new Queue<Process>();

        public frmAddProcesses()
        {
            InitializeComponent();
        }

        public frmAddProcesses(int number)
        {
            this.totalProcesses = number;
            /*int[] ids = new int[totalProcesses];

            
            for (int i = 0; i < 10; i++)
            {
                ids[i] = 0;
            } */
            InitializeComponent();
            FillOperatorsComboBox();
            ClearFields();
            lblStatus.Text = cont.ToString() + " / " + totalProcesses.ToString() + " procesos";
        }

        private void btnAddProcess_Click(object sender, EventArgs e)
        {
            string nameDeveloper = txtDeveloper.Text;
            int number1 = Convert.ToInt32(Math.Round(inputNumber1.Value, 0));
            int number2 = Convert.ToInt32(Math.Round(inputNumber2.Value, 0));
            int maxTime = Convert.ToInt32(Math.Round(inputMaxTime.Value, 0));
            int idProcess = Convert.ToInt32(Math.Round(inputIDProcess.Value, 0));
            float result = 0;
            string operation = "";

            if (number1 < 0 || number2 < 0 || maxTime <= 0 || idProcess <= 0 || string.IsNullOrEmpty(nameDeveloper))
            {
                MessageBox.Show("Algun dato es incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((cboOperator.SelectedItem.ToString() == "/" || cboOperator.SelectedItem.ToString() == "%") && number2 == 0)
            {
                MessageBox.Show("No se puede dividir entre 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (Process p in Processess)
            {
                if(p.id == idProcess)
                {
                    MessageBox.Show("No se puede repetir id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            operation = number1 + cboOperator.SelectedItem.ToString() + number2;

            switch (cboOperator.SelectedItem.ToString()[0])
            {
                case '+':
                    result = number1 + number2;
                    break;
                case '-':
                    result = number1 - number2;
                    break;
                case '*':
                    result = number1 * number2;
                    break;

                case '/':
                    result = number1 / number2;
                    break;

                case '%':
                    result = number1 % number2;
                    break;

                default:
                    result = 0;
                    break;
            }
            Process newProcess = new Process(nameDeveloper, operation, cboOperator.SelectedItem.ToString(), result, maxTime, idProcess);
            Processess.Enqueue(newProcess);
            cont++;
            int i = 0;
            if(cont == totalProcesses)
            {
                Queue<Batch> batches = new Queue<Batch>();
                Queue<Process> batch = new Queue<Process>();

                i = Convert.ToInt32(totalProcesses / 3);
                while (i > 0)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        batch.Enqueue(Processess.Dequeue());
                    }
                    batches.Enqueue(new Batch(batch));
                    batch = new Queue<Process>();
                    i--;
                }

                if(Processess.Count > 0)
                {
                    while (Processess.Count > 0)
                    {
                        batch.Enqueue(Processess.Dequeue());
                    }
                    batches.Enqueue(new Batch(batch));
                }

                frmProcessing process = new frmProcessing(batches);
                this.Hide();
                process.ShowDialog();
            } else
            {
                lblStatus.Text = cont.ToString() + " / " + totalProcesses.ToString() + " procesos";
                ClearFields();
            }
        }

        public void FillOperatorsComboBox()
        {
            cboOperator.Items.Add("+");
            cboOperator.Items.Add("-");
            cboOperator.Items.Add("*");
            cboOperator.Items.Add("/");
            cboOperator.Items.Add("%");
        }

        public void ClearFields()
        {
            txtDeveloper.Text = "";
            inputNumber1.Value = 1;
            inputNumber2.Value = 1;
            inputMaxTime.Value = 1;
            inputIDProcess.Value = 1;
            cboOperator.SelectedItem = null;
        }
    }
}
