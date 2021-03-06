﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTrees2
{
    public class Node<T> where T:IComparable
    {
        private T data;
        NodeList<T> neighbors;

        // constructors
        public Node()
        {}

        public Node(T data):this(data,null)
        {
            
        }

        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }

        public T Value
        {
            get;
            set;
        }

        public NodeList<T> Neighbors
        {
            get;
            set;
        }

        public string ToString()
        {
            return data.ToString();
        }

        public string Visit()
        {
            return data.ToString();
        }

        public int CompareTo(Node<T> node)
        {
            return this.Value.CompareTo(node.Value);
        }
    }


    public class NodeList<T>:List<Node<T>> where T:IComparable
    {
        public NodeList():base(){}

        public NodeList(int initialSize)
        {
            for (int i = 0;i<initialSize;i++)
            {
                base.Add(default(Node<T>));
            }
        }
    }

    public class BinaryTreeNode<T> : Node<T> where T:IComparable
    {
        private int m_LeftDepth = 0;
        public int LeftDepth
        {
            get { return m_LeftDepth; }
            set { m_LeftDepth = value; }
        }

        private int m_RightDepth = 0;
        public int RightDepth
        {
            get { return m_RightDepth; }
            set { m_RightDepth = value; }
        }

        private int m_Inbalance = 0;
        public int Inbalance
        {
            get { return m_Inbalance; }
            set { m_Inbalance = value; }
        }


        public BinaryTreeNode():base(){}
        public BinaryTreeNode(T data) : base(data) { }
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            NodeList<T> neighbors = new NodeList<T>();
            neighbors.Add(left);
            neighbors.Add(right);
            base.Value = data;
            base.Neighbors = neighbors;
        }


        // accessor left
        public BinaryTreeNode<T> Left
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbors[0];
            }

            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);

                base.Neighbors[0] = value;
            }
        }

        // accessor right
        public BinaryTreeNode<T> Right
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbors[1];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);
                base.Neighbors[1] =value;
            }
        }

        public string PreOrderDisplay()
        {
            if (this != null)
            {
                String str = "";
                if ((BinaryTreeNode<T>)this.Left != null)
                {
                    str += ((BinaryTreeNode<T>)this.Left).PreOrderDisplay() + "/";
                }

                 str += '('+ this.Visit() + ')';

                if ((BinaryTreeNode<T>)this.Right != null)
                {
                    str += "\\" + ((BinaryTreeNode<T>)this.Right).PreOrderDisplay();
                }

                return str;
            }
            else
            {
                return null;
            }
        }

        public BinaryTreeNode<T> PreOrder(Visit analyze, BinaryTreeNode<T> node)
        {
            System.Reflection.MethodInfo m1 = analyze.Method;
            Delegate del = (Delegate.CreateDelegate(typeof(Visit), this, m1));

            Visit localAnalyze = (Visit)del;
            
            if (localAnalyze(node))
                return this;

            if (this.Left != null)
            {
                BinaryTreeNode<T> leftNode = ((BinaryTreeNode<T>)this.Left).PreOrder(localAnalyze, node);
                if (leftNode != null)
                    return leftNode;
            }

            

            if (this.Right != null)
            {
                BinaryTreeNode<T> rightNode = ((BinaryTreeNode<T>)this.Right).PreOrder(localAnalyze, node);
                if (rightNode != null)
                    return rightNode;
            }

            return null;
        }

        public BinaryTreeNode<T> InOrder(Visit analyze, BinaryTreeNode<T> node)
        {
            System.Reflection.MethodInfo m1 = analyze.Method;
            Delegate del = (Delegate.CreateDelegate(typeof(Visit),this, m1));
            
            Visit localAnalyze = (Visit)del;
            
            if (this.Left != null)
            {
                BinaryTreeNode<T> leftNode = ((BinaryTreeNode<T>)this.Left).InOrder(localAnalyze, node);
                if (leftNode != null)
                    return leftNode;
            }

            if (localAnalyze(node))
                return this;

            if (this.Right != null)
            {
                BinaryTreeNode<T> rightNode = ((BinaryTreeNode<T>)this.Right).InOrder(localAnalyze, node);
                if (rightNode != null)
                    return rightNode;
            }

            return null;
        }

        public BinaryTreeNode<T> PostOrder(Visit analyze, BinaryTreeNode<T> node)
        {
            System.Reflection.MethodInfo m1 = analyze.Method;
            Delegate del = (Delegate.CreateDelegate(typeof(Visit), this, m1));

            Visit localAnalyze = (Visit)del;

            if (this.Left != null)
            {
                BinaryTreeNode<T> leftNode = ((BinaryTreeNode<T>)this.Left).InOrder(localAnalyze, node);
                if (leftNode != null)
                    return leftNode;
            }

            

            if (this.Right != null)
            {
                BinaryTreeNode<T> rightNode = ((BinaryTreeNode<T>)this.Right).InOrder(localAnalyze, node);
                if (rightNode != null)
                    return rightNode;
            }

            if (localAnalyze(node))
                return this;

            return null;
        }

        public int GetHeight()
        {

            if (this.Left != null)
            {
                LeftDepth = ((BinaryTreeNode<T>)(this.Left)).GetHeight();
            }
            else
            {
                LeftDepth = 0;
            }

            if (this.Right != null)
            {
                RightDepth = ((BinaryTreeNode<T>)(this.Right)).GetHeight();

            }
            else
            {
                RightDepth = 0;
            }

            Inbalance = LeftDepth - RightDepth;

            return 1 + Math.Max(LeftDepth, RightDepth);
        }

        public BinaryTreeNode<T> GetLeftmost()
        {
            BinaryTreeNode<T> leftmost = (BinaryTreeNode<T>)(this.Right);
            while (leftmost.Left != null)
            {
                leftmost = (BinaryTreeNode<T>)(leftmost.Left);
            }

            return leftmost;
        }

        public BinaryTreeNode<T> GetRightmost()
        {
            BinaryTreeNode<T> rightmost = (BinaryTreeNode<T>)(this.Left);
            while (rightmost.Right != null)
            {
                rightmost = (BinaryTreeNode<T>)(rightmost.Right);
            }

            return rightmost;
        }

        public BinaryTreeNode<T> FindParent(BinaryTreeNode<T> node)
        {
            Visit handler = isParentDelegate;
            BinaryTreeNode<T> current = InOrder(handler,node);
            return current;
        }

        public BinaryTreeNode<T> FindInBalance()
        {
            Visit handler = isInbalanced;
            BinaryTreeNode<T> current = PostOrder(handler, null);
            return current;
        }

        // delegate functions for visit
        public bool isParentDelegate(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                if (this.Left != null && this.Left.CompareTo(node) == 0)
                    return true;
                if (this.Right != null && this.Right.CompareTo(node) == 0)
                    return true;
                else
                    return false;
            }
            else
                return false;

        }

        public bool isInbalanced(BinaryTreeNode<T> node)
        {
            if (Math.Abs(this.Inbalance) > 1)
                return true;
            else
                return false;
        }
        
        public delegate bool Visit(BinaryTreeNode<T> node);

        // display functions
        public void PrintPretty(string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }
            Console.WriteLine(this.Value);

            if (this.Left != null)
                ((BinaryTreeNode<T>)(this.Left)).PrintPretty(indent, false);
            if (this.Right != null)
                ((BinaryTreeNode<T>)(this.Right)).PrintPretty(indent, true);
            
        }
    }

    

    public class BinaryTree<T> where T:IComparable
    {
        private BinaryTreeNode<T> root;

        // constructor
        public BinaryTree()
        {
        }

        public BinaryTree(T data)
        {
            root = new BinaryTreeNode<T>(data);
        }

        // clear
        private void Clear()
        {
            root = null;
        }

        // get root
        public BinaryTreeNode<T> Root
        {
            get
            {
                return root;
            }
            set
            {
                root = value;
            }
        }

        

        public string ToString()
        {
            return root.Value.ToString();
        }

        
        
    }

    public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable
    {
        public BinarySearchTree(){ }
        public BinarySearchTree(T data) : base(data) { }
        // search for a value

        // insert a value
        public virtual void InsertValue(T data)
        {
            BinaryTreeNode<T> current = Root;

            while (current != null)
            {
                if (current.Value.CompareTo(data) > 0)// value is bigger than data, go left
                {
                    // is there a left node?
                    if (current.Left == null)
                    {// left is empty, insert here
                        current.Left = new BinaryTreeNode<T>(data);
                        current = null;
                    }
                    else
                    {
                        current = (BinaryTreeNode<T>)current.Left;
                    }
                }
                else if (current.Value.CompareTo(data) < 0) // value is smaller than data, go right
                {
                    if (current.Right == null)
                    {
                        current.Right = new BinaryTreeNode<T>(data);
                        current = null;
                    }
                    else
                    {
                        current = (BinaryTreeNode<T>)current.Right;
                    }
                }
                else // value is found... do nothing
                {
                    return;
                }
            }
        }

        public BinaryTreeNode<T> FindValue(T data)
        {
            BinaryTreeNode<T> current = Root;

            while (current != null)
            {
                if (current.Value.CompareTo(data) > 0)// value is bigger than data, go left
                {
                    // is there a left node?
                    if (current.Left == null)
                    {// left is empty, insert here
                        return null;
                    }
                    else
                    {
                        current = (BinaryTreeNode<T>)current.Left;
                    }
                }
                else if (current.Value.CompareTo(data) < 0) // value is smaller than data, go right
                {
                    if (current.Right == null)
                    {
                        return null;
                    }
                    else
                    {
                        current = (BinaryTreeNode<T>)current.Right;
                    }
                }
                else // value is found... do nothing
                {
                    return current;
                }
            }
            return null;
        }


        // delete a value
        public void DeleteNode(T data)
        {// find node
            BinaryTreeNode<T> current = Root;
            BinaryTreeNode<T> parent = null;
            int result = 0;
            while (current != null)
            {
                result = current.Value.CompareTo(data);

                if  (result > 0)// value is bigger than data, go left
                {
                    // is there a left node?
                    if (current.Left == null)
                    {// left is empty, insert here
                        return;
                    }
                    else
                    {
                        parent = current;
                        current = (BinaryTreeNode<T>)current.Left;
                    }
                }
                else if (result < 0) // value is smaller than data, go right
                {
                    if (current.Right == null)
                    {
                        return;
                    }
                    else
                    {
                        parent = current;
                        current = (BinaryTreeNode<T>)current.Right;
                    }
                }
                else // value is found
                {
                    break;
                }
            }
            
            result = parent.CompareTo(current);
            if (current != null)
            {//case 1: only left tree
                if (current.Left != null && current.Right == null)
                {
                    if (result < 0)
                    {
                        parent.Left = current.Left;
                    }
                    else
                    {
                        parent.Right = current.Left;
                    }
                }
                else if (current.Right != null && current.Left == null)
                {
                    if (result < 0)
                    {
                        parent.Right = current.Right;
                    }
                    else
                    {
                        parent.Left = current.Right;
                    }
                }
                else if (current.Left == null && current.Right == null)// none of the branches have anything
                {// just delete
                    if (result < 0)
                    {
                        parent.Right = null;
                    }
                    else
                    {
                        parent.Left = null;
                    }
                }
                else
                {// get the leftmost child of the right tree
                    
                    if (result < 0)
                    {
                        parent.Right = current.GetLeftmost();
                    }
                    else
                    {
                        parent.Left = current.GetLeftmost();
                    }
                }
            }
        }

        public int GetHeight()
        {
            return this.Root.GetHeight() - 1;
        }
        

        public string ToString()
        {// show everything depth first, traversing left to right
            return this.Root.PreOrderDisplay();
        }
        
    }

    public class AVLTree<T> : BinarySearchTree<T> where T:IComparable
    {// the only difference is the insert function
        public AVLTree()
        {
        }

        public AVLTree(T data)
            : base(data)
        {
        }

        public virtual void InsertValue(T data)
        {
            // insert
            base.InsertValue(data);

            // calculate all the depths for all nodes
            this.GetHeight();

            // traverse all nodes and see if there is any inbalance
            BinaryTreeNode<T> inbalancedNode = this.Root.FindInBalance();

            while (inbalancedNode != null)
            {
                BinaryTreeNode<T> parent = this.Root.FindParent(inbalancedNode);
                this.Rotate(inbalancedNode, parent);

                this.GetHeight();
                inbalancedNode = this.Root.FindInBalance();
            }
        }

        public void Rotate(BinaryTreeNode<T> current, BinaryTreeNode<T> parent)
        {
            if (parent == null)
            {//top of tree
                if (current.Inbalance < 0) //R
                {
                    if (current.Right.Left != null)
                    {// RL
                        this.Root = current.Right.Left;
                        current.Right.Left = null;
                        this.Root.Left = current;
                        this.Root.Right = current.Right;
                        current.Right = null;
                    }
                    else
                    {// RR
                        this.Root = current.Right;
                        current.Right = null;
                        this.Root.Left = current;

                    }
                }
                else//L
                {
                    if (current.Left.Left != null)
                    {//LL
                        this.Root = current.Left;
                        current.Left = null;
                        this.Root.Right = current;
                    }
                    else
                    {// LR
                        this.Root = current.Left.Right;
                        current.Left.Right = null;
                        this.Root.Left = current.Left;
                        current.Left = null;
                        Root.Right = current;
                    }
                }
            }
            else // this is a parent, find if its left or right of parent
            {
                if (parent.CompareTo(current) < 0) // parent smaller, current is right of parent
                {
                    if (current.Inbalance < 0) //R
                    {
                        if (current.Right.Left != null)
                        {// RL
                            parent.Right = current.Right.Left;
                            current.Right.Left = null;
                            parent.Right.Left = current;
                            parent.Right.Right = current.Right;
                            current.Right = null;
                        }
                        else
                        {// RR
                            parent.Right = current.Right;
                            current.Right = null;
                            parent.Right.Left = current;

                        }
                    }
                    else//L
                    {
                        if (current.Left.Left != null)
                        {//LL
                            parent.Right = current.Left;
                            current.Left = null;
                            parent.Right.Right = current;
                        }
                        else
                        {// LR
                            parent.Right = current.Left.Right;
                            current.Left.Right = null;
                            parent.Right.Left = current.Left;
                            current.Left = null;
                            parent.Left.Right = current;
                        }
                    }
                }
                else
                {// parent is larger, current is left of parent
                    
                    if (current.Inbalance < 0) //R
                    {
                        if (current.Right.Left != null)
                        {// RL
                            parent.Left = current.Right.Left;
                            current.Right.Left = null;
                            parent.Left.Left = current;
                            parent.Left.Right = current.Right;
                            current.Right = null;
                        }
                        else
                        {// RR
                            parent.Left = current.Right;
                            current.Right = null;
                            parent.Left.Left = current;

                        }
                    }
                    else//L
                    {
                        if (current.Left.Left != null)
                        {//LL
                            parent.Left = current.Left;
                            current.Left = null;
                            parent.Left.Right = current;
                        }
                        else
                        {// LR
                            parent.Left = current.Left.Right;
                            current.Left.Right = null;
                            parent.Left.Left = current.Left;
                            current.Left = null;
                            parent.Left.Right = current;
                        }
                    }
                }
            }
        }

    }

}
