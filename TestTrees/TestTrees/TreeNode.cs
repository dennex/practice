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

    public class BinaryTree
    {
        private TreeNode root;
        internal TreeNode Root
        {
            get { return root; }
            set { root = value; }
        }

        private BinaryTree leftTree;
        public BinaryTree LeftTree
        {
            get { return leftTree; }
            set { leftTree = value; }
        }

        private BinaryTree rightTree;
        public BinaryTree RightTree
        {
            get { return rightTree; }
            set { rightTree = value; }
        }

        public BinaryTree()
        {

        }

        public BinaryTree(BinaryTree tree)
        {
            this.root = tree.root;
            this.leftTree = tree.leftTree;
            this.rightTree = tree.rightTree;
        }

        public BinaryTree(TreeNode root, BinaryTree left, BinaryTree right)
        {
            this.root = root;
            this.leftTree = left;
            this.rightTree = right;

        }

        public string ToString()
        {
            return this.root.Value.ToString();
        }


        // traversal methods
        // depth first
        public static void PreOrder(BinaryTree tree)
        {
            if (tree != null)
            {
                tree.Root.Visit();
                PreOrder(tree.leftTree);
                PreOrder(tree.rightTree);
            }
        }

        public static void InOrder(BinaryTree tree)
        {
            if (tree != null)
            {
                InOrder(tree.leftTree);
                tree.Root.Visit();
                InOrder(tree.rightTree);
            }
        }

        public static void PostOrder(BinaryTree tree)
        {
            if (tree != null)
            {
                PostOrder(tree.leftTree);
                PostOrder(tree.rightTree);
                tree.Root.Visit();
            }
        }

        public static void BreadthFirst(BinaryTree tree)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(tree.root);
            while (q.Count!=0)
            {
                TreeNode current = q.Dequeue();
                if (current != null)
                {
                    current.Visit();
                    q.Enqueue(current.Left);
                    q.Enqueue(current.Right);
                }
            }
        }

    }

    public class BinarySearchTree
    {
        // same as Binary Tree but add functions for search, insert, delete
        private TreeNode FindBST(int value)
        {// assume the tree is BST

        }

        // check that it is BST

        // make this into a BST

        // insert into BST

        // delete from a BST
    }
}
