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
        // new times
        public int t_llegada = 0;
        public int t_finalizacion = 0;
        public int t_retorno = 0;
        public int t_respuesta = 0;
        public int t_espera = 0;
        public int t_servicio = 0;


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
    }
}
