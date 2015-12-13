using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTrees
{
    public class TreeNode
    {
        private int value;
        public int Value
        {
          get { return this.value; }
          set { this.value = value; }
        }

        private TreeNode parent;
        internal TreeNode Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        private TreeNode left;
        internal TreeNode Left
        {
            get { return left; }
            set { left = value; }
        }

        private TreeNode right;
        internal TreeNode Right
        {
            get { return right; }
            set { right = value; }
        }

        public TreeNode()
        {
            this.parent = null;
            this.left = null;
            this.right = null;
        }

        public TreeNode(int value, TreeNode par)
        {
            this.value = value;
            this.parent = par;
        }

        public TreeNode(TreeNode node)
        {
            this.value = node.value;
            this.parent = node.parent;
        }

        public void Visit()
        {
            Console.Write(value.ToString());
        }

        public string ToString()
        {
            return this.value.ToString();
        }

    }

    public class BinaryTree:TreeNode
    {
        public TreeNode root;

        public BinaryTree()
        {
        }


        public BinaryTree(TreeNode root, BinaryTree left, BinaryTree right)
        {
            this.root = root;
            this.Left = left;
            this.Right = right;

        }

        public BinaryTree(TreeNode root)
        {
            this.root = root;
            this.Left = null;
            this.Right = null;
        }

        public BinaryTree(int value)
        {
            this.root = new TreeNode(value, null);
            this.Left = null;
            this.Right = null;
        }

        public string ToString()
        {
            return this.root.Value.ToString();
        }


        // traversal methods
        // depth first
        public void PreOrder()
        {
            if (this != null)
            {
                this.Visit();
                ((BinaryTree)this.Left).PreOrder();
                ((BinaryTree)this.Right).PreOrder();
            }
        }

        //public static void InOrder(BinaryTree tree)
        //{
        //    if (tree != null)
        //    {
        //        InOrder(tree.leftTree);
        //        tree.Root.Visit();
        //        InOrder(tree.rightTree);
        //    }
        //}

        //public static void PostOrder(BinaryTree tree)
        //{
        //    if (tree != null)
        //    {
        //        PostOrder(tree.leftTree);
        //        PostOrder(tree.rightTree);
        //        tree.Root.Visit();
        //    }
        //}

        //public static void BreadthFirst(BinaryTree tree)
        //{
        //    Queue<TreeNode> q = new Queue<TreeNode>();
        //    q.Enqueue(tree.root);
        //    while (q.Count!=0)
        //    {
        //        TreeNode current = q.Dequeue();
        //        if (current != null)
        //        {
        //            current.Visit();
        //            q.Enqueue(current.Left);
        //            q.Enqueue(current.Right);
        //        }
        //    }
        //}

    }

    public class BinarySearchTree: BinaryTree
    {


        //// same as Binary Tree but add functions for search, insert, delete
        //public TreeNode FindBST(int value)
        //{// assume the tree is BST
        //    TreeNode current = this;

        //    while (current != null)
        //    {
        //        // is it larger?
        //        if (current.Value < value)
        //        {// look right
        //            if (this.Right != null)
        //            {
        //                current = current.Right;
        //            }
        //        }
        //        else if (current.Value > value)
        //        {   // is it smaller?
        //            if (current.Left != null)
        //            {
        //                current = current.Left;
        //            }
        //        }
        //        else
        //        {   // then its equal!
        //            return current;
        //        }

        //    }

        //    return null;

        //}

        // check that it is BST

        // make this into a BST

        // insert into BST
        // same as Binary Tree but add functions for search, insert, delete
        public void InsertBST(int value)
        {// assume the tree is BST
            TreeNode current = this;
         
            while (current != null)
            {
                // is it larger?
                if (current.Value < value)
                {// look right
                    if (this.Right != null)
                    {
                        current = current.Right;
                    }
                    else
                    {// insert!

                        current.Right = new TreeNode(value, current);
                        current = null;
                    }
                }
                else if (current.Value > value)
                {   // is it smaller?
                    if (this.Left != null)
                    {
                        current = current.Left;
                    }
                    else
                    {// insert!
                        current.Left = new TreeNode(value, current);
                        current = null;
                    }
                }
                else
                {   // then its equal!
                    current = null;
                }
                

            }
        }

        // delete from a BST
    }
}
