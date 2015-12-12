using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTrees
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //#region binary tree test
            //TreeNode one = new TreeNode(1, null);
            //TreeNode two = new TreeNode(2, one);
            //TreeNode three = new TreeNode(3, one);
            //TreeNode four = new TreeNode(4, two);
            //TreeNode five = new TreeNode(5, two);
            //TreeNode six = new TreeNode(6, three);
            //TreeNode seven = new TreeNode(7, three);
            //one.Left = two;
            //one.Right = three;
            //two.Left = four;
            //two.Right = five;
            //three.Left = six;
            //three.Right = seven;
            
            //BinaryTree tree7 = new BinaryTree(seven, null, null);
            //BinaryTree tree6 = new BinaryTree(six, null, null);
            //BinaryTree tree5 = new BinaryTree(five, null, null);
            //BinaryTree tree4 = new BinaryTree(four, null, null);
            //BinaryTree tree3 = new BinaryTree(three, tree6, tree7);
            //BinaryTree tree2 = new BinaryTree(two, tree4, tree5);
            //BinaryTree tree1 = new BinaryTree(one,tree2, tree3);

            ////BinaryTree.PreOrder(tree1);
            ////Console.WriteLine();
            ////BinaryTree.InOrder(tree1);
            ////Console.WriteLine();
            ////BinaryTree.PostOrder(tree1);
            ////Console.WriteLine();

            //BinaryTree.BreadthFirst(tree1);

            //#endregion

            // populate a binary search tree


        }
    }
}
