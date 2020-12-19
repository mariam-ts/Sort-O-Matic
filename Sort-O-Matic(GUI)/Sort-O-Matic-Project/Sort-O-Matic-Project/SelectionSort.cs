using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_O_Matic_Project
{
    class SelectionSort : ISortEngine
    {
        int[] MyArray;
        Graphics graph;
        int UpperBound;

        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush RedBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        int temp, smallest;
        public void DoWork(int[] MyArray, Graphics graph, int UpperBound)
        {
            this.MyArray = MyArray;
            this.graph = graph;
            this.UpperBound = UpperBound;

            //The algorithm builds the sorted list from the left.
            //1. For each item in the array...
            for (int i = 0; i < this.MyArray.Length - 1; i++)
            {
                //2. ...assume the first item is the smallest value
                smallest = i;
                //3. Cycle through the rest of the array
                for (int j = i + 1; j < this.MyArray.Length; j++)
                {
                    //4. If any of the remaining values are smaller, 
                    //   find the smallest of these
                    if (this.MyArray[j] < this.MyArray[smallest])
                    {
                        smallest = j;
                    }
                }
                //red brush will show me which indexes are checked
                graph.FillRectangle(WhiteBrush, i, 0, 1, UpperBound);
                graph.FillRectangle(RedBrush, i, UpperBound - MyArray[i], 1, UpperBound);

                graph.FillRectangle(WhiteBrush, smallest, 0, 1, UpperBound);
                graph.FillRectangle(RedBrush, smallest, UpperBound - MyArray[smallest], 1, UpperBound);
                //5. Swap the found-smallest value with the current value

                SwapValues(smallest, i);
                

            }
        }
        private void SwapValues(int i, int v)
        {
            //swap values
            int temp = MyArray[i];
            MyArray[i] = MyArray[v];
            MyArray[v] = temp;

            //also swap the brushes
            graph.FillRectangle(WhiteBrush, i, 0, 1, UpperBound);
            graph.FillRectangle(WhiteBrush, v, 0, 1, UpperBound);

            graph.FillRectangle(BlackBrush, i, UpperBound - MyArray[i], 1, UpperBound);
            graph.FillRectangle(BlackBrush, v, UpperBound - MyArray[v], 1, UpperBound);

        }

    }
}
