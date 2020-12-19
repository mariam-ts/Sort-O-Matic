using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Threading.Tasks;

namespace Sort_O_Matic_Project
{
    public partial class Form1 : Form
    {
        int[] MyArray;
        int[] MyArray2;
        Graphics graph;
        Graphics graph2;
        int length;
        string method1;
        string method2;
        public Form1()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.length = sizePicker.Value;
            label1.Text = "Please choose length: " + sizePicker.Value.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
             this.method1 = SortMethod.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graph = panel1.CreateGraphics();
            int Entries = this.length;
            int UpperBoud = panel1.Height;
            MyArray = new int[Entries];
            graph.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), 0, 0, panel1.Width, UpperBoud);
            Random randNum = new Random();
            for(var i = 0; i <Entries; ++i)
            {
                MyArray[i] = randNum.Next(0, UpperBoud);
            }
            for (var i = 0; i < Entries; ++i)
            {
                graph.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), i, UpperBoud - MyArray[i], 1, UpperBoud);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Generator_SelectedIndexChanged(object sender, EventArgs e)
        {
            graph = panel1.CreateGraphics();
            int Entries = this.length;
            int UpperBoud = panel1.Height;
            MyArray = new int[Entries];
            graph.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), 0, 0, panel1.Width, UpperBoud);
            Random randNum = new Random();
            for (var i = 0; i < Entries; ++i)
            {
                MyArray[i] = randNum.Next(0, UpperBoud);
            }

            if (Generator.SelectedItem == "random")
            {
                for (var i = 0; i < Entries; ++i)
                {
                    graph.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), i, UpperBoud - MyArray[i], 1, UpperBoud);
                }
            }
            else if(Generator.SelectedItem == "data in ascending order")
            {
                Array.Sort(MyArray);
                for (var i = 0; i < Entries; ++i)
                {
                    graph.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), i, UpperBoud - MyArray[i], 1, UpperBoud);
                }

            }
            else if (Generator.SelectedItem == "data in descending order")
            {
                Array.Sort(MyArray);
                Array.Reverse(MyArray);
                for (var i = 0; i < Entries; ++i)
                {
                    graph.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), i, UpperBoud - MyArray[i], 1, UpperBoud);
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            Task.Run(() =>
            {
                if (this.method1 == "Bubble Sort")
                {
                    var bubble = new BubbleSort();
                    bubble.DoWork(MyArray, graph, panel1.Height);

                }
                else if (this.method1 == "Insertion Sort")
                {
                    var insertion = new InsertionSort();
                    insertion.DoWork(MyArray, graph, panel1.Height);

                }
                else if (this.method1 == "Quick Sort")
                {
                    var quick = new QuickSort();
                    quick.DoWork(MyArray, graph, panel1.Height);

                }
                else if (this.method1 == "Selection Sort")
                {
                    var select = new SelectionSort();
                    select.DoWork(MyArray, graph, panel1.Height);
                }
            });

            Task.Run(() =>
            {
                if (this.method2 == "Bubble Sort")
                {
                    var bubble2 = new BubbleSort();
                    bubble2.DoWork(MyArray2, graph2, panel2.Height);

                }
                else if (this.method2 == "Insertion Sort")
                {
                    var insertion2 = new InsertionSort();
                    insertion2.DoWork(MyArray2, graph2, panel2.Height);

                }
                else if (this.method2 == "Quick Sort")
                {
                    var quick2 = new QuickSort();
                    quick2.DoWork(MyArray2, graph2, panel2.Height);
                }
                else if (this.method2 == "Selection Sort")
                {
                    var select2 = new SelectionSort();
                    select2.DoWork(MyArray2, graph2, panel2.Height);
                }
            });





        }
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            graph2 = panel2.CreateGraphics();
            int Entries = this.length;
            int UpperBoud = panel2.Height;
            MyArray2 = new int[Entries];
            graph2.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), 0, 0, panel2.Width, UpperBoud);
            Random randNum = new Random();
            for (var i = 0; i < Entries; ++i)
            {
                MyArray2[i] = randNum.Next(0, UpperBoud);
            }

            if (Generator.SelectedItem == "random")
            {
                for (var i = 0; i < Entries; ++i)
                {
                    graph2.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), i, UpperBoud - MyArray2[i], 1, UpperBoud);
                }
            }
            else if (Generator.SelectedItem == "data in ascending order")
            {
                Array.Sort(MyArray2);
                for (var i = 0; i < Entries; ++i)
                {
                    graph2.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), i, UpperBoud - MyArray2[i], 1, UpperBoud);
                }

            }
            else if (Generator.SelectedItem == "data in descending order")
            {
                Array.Sort(MyArray2);
                Array.Reverse(MyArray2);
                for (var i = 0; i < Entries; ++i)
                {
                    graph2.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), i, UpperBoud - MyArray2[i], 1, UpperBoud);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.method2 = comboBox1.SelectedItem.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
