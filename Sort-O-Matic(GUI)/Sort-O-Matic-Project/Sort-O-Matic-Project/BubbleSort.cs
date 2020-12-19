using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_O_Matic_Project
{
    class BubbleSort : ISortEngine
    {
        bool _sorted = false;
        int[] MyArray;
        Graphics graph;
        int UpperBound;
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush RedBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        public void DoWork(int[] MyArray, Graphics graph, int UpperBound)
        {
            this.MyArray = MyArray;
            this.graph = graph;
            this.UpperBound = UpperBound;

            while (!_sorted)
            {
                for(int i = 0; i<MyArray.Count()-1; ++i)
                {
                    if (MyArray[i] > MyArray[i + 1])
                    {
                        graph.FillRectangle(WhiteBrush, i, 0, 1, UpperBound);
                        graph.FillRectangle(RedBrush, i, UpperBound - MyArray[i], 1, UpperBound);

                        graph.FillRectangle(WhiteBrush, i+1, 0, 1, UpperBound);
                        graph.FillRectangle(RedBrush, i+1, UpperBound - MyArray[i+1], 1, UpperBound);
                        SwapValues(i, i + 1);
                    }
                }
                _sorted = IsSorted();

            }
        }

        private void SwapValues(int i, int v)
        {
            int temp = MyArray[i];
            MyArray[i] = MyArray[v];
            MyArray[v] = temp;

            graph.FillRectangle(WhiteBrush, i, 0, 1, UpperBound);
            graph.FillRectangle(WhiteBrush, v, 0, 1, UpperBound);

            graph.FillRectangle(BlackBrush, i, UpperBound-MyArray[i], 1, UpperBound);
            graph.FillRectangle(BlackBrush, v, UpperBound - MyArray[v], 1, UpperBound);

        }

        private bool IsSorted()
        {
            for(var i = 0; i< MyArray.Count()-1; ++i)
            {
                if (MyArray[i] > MyArray[i + 1])
                    return false;
            }
            return true;
        }
    }
}
