using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa1
{
    public class Batch
    {
        public Queue<Process> Processes;

        public Batch()
        {
            Processes = new Queue<Process>();
        }

        public Batch(Queue<Process> Processes)
        {
            this.Processes = Processes;
        }
    }
}
