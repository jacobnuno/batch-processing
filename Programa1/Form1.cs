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
        int totalProcesses = 0;
        int cont = 0;
        int ids = 0;
        Queue<Process> Processess = new Queue<Process>();

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
            totalProcesses = processNumber;
            AddProcessess();
        }

        private static Random random = new Random();

        private int GetRandomNumber(int max, int min)
        {
            return Convert.ToInt32(Math.Round(random.NextDouble() * (max - min) + min));
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private char GetRandomOperator()
        {
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

        private void AddProcessess()
        {
            for(int k = 0; k < totalProcesses; k++)
            {
                string nameDeveloper = RandomString(5);
                int number1 = GetRandomNumber(100, 1);
                int number2 = GetRandomNumber(100, 1);
                int maxTime = GetRandomNumber(30, 7);
                int idProcess = ++ids;
                string result = "";
                char myOperator = GetRandomOperator();
                string operation = number1.ToString() + myOperator + number2.ToString();

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
                Process newProcess = new Process(nameDeveloper, operation, myOperator, result, maxTime, idProcess);
                Processess.Enqueue(newProcess);
                cont++;
                int i = 0;
                if (cont == totalProcesses)
                {
                    Queue<Batch> batches = new Queue<Batch>();
                    Queue<Process> batch = new Queue<Process>();

                    i = Convert.ToInt32(totalProcesses / 3);
                    while (i > 0)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            batch.Enqueue(Processess.Dequeue());
                        }
                        batches.Enqueue(new Batch(batch));
                        batch = new Queue<Process>();
                        i--;
                    }

                    if (Processess.Count > 0)
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
                }
            }
        }
    }
}
