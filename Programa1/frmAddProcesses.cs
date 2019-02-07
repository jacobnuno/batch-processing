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
    {/*
        int totalProcesses = 0;
        int cont = 0;
        int ids = 0;
        Queue<Process> Processess = new Queue<Process>(); */

        public frmAddProcesses()
        {
            InitializeComponent();
        }

        public frmAddProcesses(int number)
        {
            InitializeComponent(); /*
            this.totalProcesses = number;
            FillOperatorsComboBox();
            ClearFields();
            lblStatus.Text = cont.ToString() + " / " + totalProcesses.ToString() + " procesos"; */
        }

        private int GetRandomNumber(int max, int min)
        {
            Random random = new Random();
            return Convert.ToInt32(Math.Round(random.NextDouble() * (max - min) + min));
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random randomString = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[randomString.Next(s.Length)]).ToArray());
        }

        private char GetRandomOperator()
        {
            Random random = new Random();
            char myOperator = ' ';
            switch (GetRandomNumber(5, 1))
            {
                case 1:
                    myOperator = '+';
                    break;
                case 2:
                    myOperator = '-';
                    break;
                case 3:
                    myOperator = '*';
                    break;
                case 4:
                    myOperator = '/';
                    break;
                case 5:
                    myOperator = '%';
                    break;
            }
            return myOperator;
        }

        private void btnAddProcess_Click(object sender, EventArgs e)
        { /*
            string nameDeveloper = RandomString(5);
            int number1 = GetRandomNumber(100, 1);
            int number2 = GetRandomNumber(100, 1);
            int maxTime = GetRandomNumber(30, 7);
            int idProcess = ++ids;
            string result = GetRandomOperator(number1, number2);
            string operation = number1.ToString() + myOperator + number2.ToString();
            
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

            switch (myOperator)
            {
                case '+':
                    result = (number1 + number2).ToString();
                    break;
                case '-':
                    result = (number1 - number2).ToString();
                    break;
                case '*':
                    result = (number1 * number2).ToString();
                    break;

                case '/':
                    result = (number1 / number2).ToString();
                    break;

                case '%':
                    result = (number1 % number2).ToString();
                    break;

                default:
                    result = "";
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
            } */
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
