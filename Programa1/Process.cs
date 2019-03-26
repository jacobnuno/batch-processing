using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa1
{
    public class Process
    {
        public int id = 0;
        public int maxTime = 0;
        public int leftTime = 0;
        public int executionTime = 0;
        public string nameDeveloper = "";
        public string operation = "";
        public char myOperator = ' ';
        public string result = "";
        public int noBatch = 0;
        public int locked = 0;
        public bool isFinished = false;
        // new times
        public int t_llegada = -1;
        public int t_finalizacion = -1;
        public int t_retorno = -1;
        public int t_respuesta = -1;
        public int t_espera = -1;
        public int t_servicio = -1;
        public int leftTimeAux = -1;
        public int executionQuantum = 0;

        /*public int t_llegada = 0;
        public int t_finalizacion = 0;
        public int t_retorno = 0;
        public int t_respuesta = -1;
        public int t_espera = 0;
        public int t_servicio = 0;
        public int leftTimeAux = 0;*/


        public Process(string nameDeveloper, string operation, char myOperator, string result, int maxTime, int idProcess)
        {
            this.id = idProcess;
            this.maxTime = maxTime;
            this.leftTime = maxTime;
            this.nameDeveloper = nameDeveloper;
            this.operation = operation;
            this.myOperator = myOperator;
            this.result = result;
        }

        private static Random random = new Random();

        public static int GetRandomNumber(int max, int min)
        {
            return Convert.ToInt32(Math.Round(random.NextDouble() * (max - min) + min));
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static char GetRandomOperator()
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

        public Process(int idProcess)
        {
            this.nameDeveloper = Process.RandomString(5);
            int number1 = Process.GetRandomNumber(100, 1);
            int number2 = Process.GetRandomNumber(100, 1);
            this.maxTime = Process.GetRandomNumber(18, 7);
            this.leftTime = maxTime;
            this.id = idProcess;
            this.result = "";
            this.myOperator = Process.GetRandomOperator();
            this.operation = number1.ToString() + myOperator + number2.ToString();

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
        }
    }
}
