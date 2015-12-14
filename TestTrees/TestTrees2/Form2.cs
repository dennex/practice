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

            Console.WriteLine( (tree.FindValue(3)).ToString());
            //tree.DeleteNode(16);
            //tree.DeleteNode(0);

            tree.GetHeight();
            BinaryTreeNode<int> current = tree.FindValue(20);
            BinaryTreeNode<int> parent = tree.Root.FindParent(current);
        }
    }
}
