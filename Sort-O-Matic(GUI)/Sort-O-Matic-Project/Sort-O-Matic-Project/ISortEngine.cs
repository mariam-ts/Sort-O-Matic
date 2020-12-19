using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Sort_O_Matic_Project
{
    interface ISortEngine
    {
        void DoWork(int[] MyArray, Graphics graph, int UpperBound);
    }
}
