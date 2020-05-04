using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_cs
{
    public class IndexerClass
    {
        double[] array;
        int firstIndex, lastIndex;
        public IndexerClass(double[] array, int firstIndex, int length)
        {
            if (firstIndex < 0 || length <= 0 || array.Length <= firstIndex + length)
                throw new ArgumentException();
            this.array = array;
            this.firstIndex = firstIndex;
            this.lastIndex = firstIndex + length - 1;
        }
        public int Length
        {
            get => this.lastIndex - this.firstIndex + 1;
        }
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Length)
                    throw new IndexOutOfRangeException();
                return this.array[index + firstIndex];
            }
            set
            {
                if (index < 0 || index >= this.Length)
                    throw new IndexOutOfRangeException();
                this.array[index + firstIndex] = value;
            }
        }

    }
}
