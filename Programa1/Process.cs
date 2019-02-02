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
        public string nameDeveloper = "";
        public string operation = "";
        public string myOperator = "";
        public float result = 0;
        public int noBatch = 0;

        public Process(string nameDeveloper, string operation, string myOperator, float result, int maxTime, int idProcess)
        {
            this.id = idProcess;
            this.maxTime = maxTime;
            this.nameDeveloper = nameDeveloper;
            this.operation = operation;
            this.myOperator = myOperator;
            this.result = result;
        }
    }
}
