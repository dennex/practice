using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTrees2
{
    public class Node<T>
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
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public NodeList<T> Neighbors
        {
            get
            {
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }

        public string ToString()
        {
            return data.ToString();
        }

        public string Visit()
        {
            return data.ToString();
        }
    }


    public class NodeList<T>:List<Node<T>>
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

    public class BinaryTreeNode<T> : Node<T>
    {
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


        // method for get left
        public Node<T> Left
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

        // method for get right
        public Node<T> Right
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

        public string PreOrder()
        {
            if (this != null)
            {
                String str = "";
                if ((BinaryTreeNode<T>)this.Left != null)
                {
                    str += "," + ((BinaryTreeNode<T>)this.Left).PreOrder();
                }

                 str += "," + this.Visit();

                if ((BinaryTreeNode<T>)this.Right != null)
                {
                    str += "," + ((BinaryTreeNode<T>)this.Right).PreOrder();
                }

                return str;
            }
            else
            {
                return null;
            }
        }
    }

    public class BinaryTree<T>
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
            
            result = parent.Value.CompareTo(current.Value);
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
                    BinaryTreeNode<T> leftmost = (BinaryTreeNode<T>)(current.Right);
                    while (leftmost.Left != null)
                    {
                        leftmost = (BinaryTreeNode<T>)(leftmost.Left);
                    }
                    if (result < 0)
                    {
                        parent.Right = leftmost;
                    }
                    else
                    {
                        parent.Left = leftmost;
                    }
                }

                

            }
        }

        public void Rotation()
        {

        }
        

        

        public string ToString()
        {// show everything depth first, traversing left to right
            return this.Root.PreOrder();
        }
        
    }
}
