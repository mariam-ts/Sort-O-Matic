using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_O_Matic_Project
{
    class InsertionSort : ISortEngine
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
            // while is not sorted
            while (!_sorted)
            {

                int i, j;

                for (i = 1; i < MyArray.Length; i++)
                {
                    j = i;

                    // Insert MyArray[i] into list 0..i-1 
                    while (j > 0 && MyArray[j] < MyArray[j - 1])
                    {
                        //red brush will show me which indexes are checked
                        graph.FillRectangle(WhiteBrush, i, 0, 1, UpperBound);
                        graph.FillRectangle(RedBrush, i, UpperBound - MyArray[i], 1, UpperBound);

                        graph.FillRectangle(WhiteBrush, j-1, 0, 1, UpperBound);
                        graph.FillRectangle(RedBrush, j-1, UpperBound - MyArray[j - 1], 1, UpperBound);
                        // Swap MyArray[j] and MyArray[j-1] 
                        SwapValues(i, j - 1);

                        // Decrement j by 1 
                        j -= 1;
                    }
                }
                //check if it's sorted
                _sorted = IsSorted();
            }
        }
        private bool IsSorted()
        {
            for (var i = 0; i < MyArray.Count() - 1; ++i)
            {
                //if one of the member is greater then the next it's not sorted return false
                if (MyArray[i] > MyArray[i + 1])
                    return false;
            }
            //otherwise true
            return true;
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
