using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa1
{
    public class Memory
    {
        public List<Frame> Frames;
        public int Size;
        public int FrameSize;

        public Memory(int Size, int FrameSize)
        {
            this.Size = Size;
            this.FrameSize = FrameSize;
            this.Frames = new List<Frame>();

            for(int i = 0; i < Size; i++)
            {
                Frames.Add(new Frame(i));
            }
        }

        public int getAvailableSize()
        {
            int Available = 0;

            foreach(Frame F in Frames)
            {
                if (F.Status == 0) Available++;
            }

            return Available;
        }

        public bool canAccess(double FramesNeeded)
        {
            if (getAvailableSize() < FramesNeeded) return false;

            return true;
        }

        public void addProcess(Process P)
        {
            if (!canAccess(P.Size / (double)FrameSize))
            {
                return;
            }

            int ProcessSize = P.Size;
            int count = 0;

            while (ProcessSize > 0)
            {
                if (Frames[count].Status == 0)
                {
                    Frames[count].Process = P.id;
                    Frames[count].Status = 1;

                    if (ProcessSize > FrameSize) Frames[count].Memory = FrameSize;
                    else Frames[count].Memory = ProcessSize;

                    ProcessSize -= FrameSize;
                }

                count++;
            }
        }

        public void changeStatus(int ProcessNumber, int Status)
        {
            foreach(Frame F in Frames)
            {
                if (F.Process == ProcessNumber) F.Status = Status;
            }
        }

        public void removeProcess(int ProcessNumber)
        {
            foreach (Frame F in Frames)
            {
                if (F.Process == ProcessNumber)
                {
                    F.Status = 0;
                    F.Memory = 0;
                }
            }
        }
    }
}
