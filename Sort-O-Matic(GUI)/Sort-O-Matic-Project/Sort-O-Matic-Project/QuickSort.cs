using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_O_Matic_Project
{
    class QuickSort:ISortEngine
    {
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

            quickSort(MyArray, 0, MyArray.Length - 1);
            
        }
        private int partition(int[] arr, int low,
                                  int high)
        {
            int pivot = arr[high];

            // index of smaller element 
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                // If current element is smaller  
                // than the pivot 
                if (arr[j] < pivot)
                {
                    i++;

                    // swap arr[i] and arr[j] 
                    //red brush will show me which indexes are checked
                    graph.FillRectangle(WhiteBrush, i, 0, 1, UpperBound);
                    graph.FillRectangle(RedBrush, i, UpperBound - MyArray[i], 1, UpperBound);

                    graph.FillRectangle(WhiteBrush, j , 0, 1, UpperBound);
                    graph.FillRectangle(RedBrush, j , UpperBound - MyArray[j], 1, UpperBound);
                    SwapValues(i, j);

                }
            }

            // swap arr[i+1] and arr[high] (or pivot) 
            //red brush will show me which indexes are checked
            graph.FillRectangle(WhiteBrush, i+1, 0, 1, UpperBound);
            graph.FillRectangle(RedBrush, i+1, UpperBound - MyArray[i+1], 1, UpperBound);

            graph.FillRectangle(WhiteBrush, high, 0, 1, UpperBound);
            graph.FillRectangle(RedBrush, high, UpperBound - MyArray[high], 1, UpperBound);

            SwapValues(i+1, high);

            return i + 1;
        }


        /* The main function that implements QuickSort() 
        arr[] --> Array to be sorted, 
        low --> Starting index, 
        high --> Ending index */
        private void quickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {

                /* pi is partitioning index, arr[pi] is  
                now at right place */
                int pi = partition(arr, low, high);

                // Recursively sort elements before 
                // partition and after partition 
                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
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
