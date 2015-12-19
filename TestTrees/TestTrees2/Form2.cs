using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTrees2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(5);
            tree.InsertValue(10);
            tree.InsertValue(15);
            tree.InsertValue(3);
            tree.InsertValue(0);
            tree.InsertValue(-10);
            tree.InsertValue(16);
            tree.InsertValue(20);
            tree.InsertValue(10);
            tree.InsertValue(1);
            tree.InsertValue(2);

            //Console.WriteLine( (tree.FindValue(3)).ToString());
            //tree.DeleteNode(16);
            //tree.DeleteNode(0);

            Random rnd = new Random();
            AVLTree<int> tree2 = new AVLTree<int>(0);
            //for (int I = 0; I < 20; I++)
            //{
            //    int rand = rnd.Next(100);
            //    tree2.InsertValue(rand);
            //    tree2.Root.PrintPretty("", true);
            //}
            List<int> inputs = new List<int>();

            for (int i = 0; i < 20; i++)
            {
                inputs.Add(rnd.Next(100));
            }
            //int [] inputs = {28,63,97,51,93,65,49,10,91,44,29,59,49,28,85,39,79,7,97,19};

            for (int i = 0; i < inputs.Count(); i++)
            {
                if (i == 7)
                    i = 7;
                tree2.InsertValue(inputs[i]);
            }
            tree2.Root.PrintPretty("", true);
        }
    }
}
