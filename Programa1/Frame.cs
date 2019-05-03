using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa1
{
    /*
     Status:
        -1: SO
         0: Available
         1: Ready
         2: Running
         3: Blocked
    */

    public class Frame
    {
        public int ID;
        public int Process;
        public int Status;
        public int Memory;

        public Frame(int ID)
        {
            this.ID = ID;
            this.Process = 0;
            this.Status = 0;
            this.Memory = 0;
        }
    }
}
