using System;

namespace AvlTree
{
    public class AvlNode
    {
        public int Value { get; set; }

        public int Height { get; set; } = 1;

        public int Factor => (Left?.Height ?? 0) - (Right?.Height ?? 0);

        public AvlNode Left { get; set; }

        public AvlNode Right { get; set; }

        public AvlNode Parent { get; set; }

        public bool IsLeftChild => Parent?.Left == this;

        public bool IsRightChild => Parent?.Right == this;
    }

    class Program
    {
        static AvlNode CloneNode(AvlNode node)
        {
            if (node == null)
            {
                return null;
            }

            var ret = new AvlNode
            {
                Left = node.Left,
                Right = node.Right,
                Parent = node.Parent,
                Value = node.Value,
                Height = node.Height
            };

            return ret;
        }

        static void ModifyLL(AvlNode node)
        {
            // Adjust nodes
            var newLeft = CloneNode(node?.Left?.Left);
            newLeft.Parent = node;
            if (newLeft.Left != null)
            {
                newLeft.Left.Parent = newLeft;
            }
            if (newLeft.Right != null)
            {
                newLeft.Right.Parent = newLeft;
            }

            var newRight = CloneNode(node);
            newRight.Parent = node;
            newRight.Left = node?.Left?.Right;
            if (newRight.Right != null)
            {
                newRight.Right.Parent = newRight;
            }

            node.Value = node.Left.Value;
            node.Left = newLeft;
            node.Right = newRight;

            // Adjust height
            node.Height -= 1;
            node.Right.Height -= 2;
            MaintainHeightAfterInsert(node);
        }

        static void ModifyRR(AvlNode node)
        {
            // Adjust nodes
            var newLeft = CloneNode(node);
            newLeft.Parent = node;
            newLeft.Right = node?.Right?.Left;
            if (newLeft.Left != null)
            {
                newLeft.Left.Parent = newLeft;
            }

            var newRight = CloneNode(node?.Right?.Right);
            newRight.Parent = node;
            if (newRight.Left != null)
            {
                newRight.Left.Parent = newRight;
            }
            if (newRight.Right != null)
            {
                newRight.Right.Parent = newRight;
            }

            node.Value = node.Right.Value;
            node.Left = newLeft;
            node.Right = newRight;

            // Adjust height
            node.Height -= 1;
            node.Left.Height -= 2;
            MaintainHeightAfterInsert(node);
        }

        static void ModifyLR(AvlNode node)
        {
            // Adjust nodes
            var newLeft = CloneNode(node.Left);
            newLeft.Parent = node;
            newLeft.Right = node?.Left?.Right?.Left;
            if (newLeft.Left != null)
            {
                newLeft.Left.Parent = newLeft;
            }
            var newRight = CloneNode(node);
            newRight.Parent = node;
            newRight.Left = node?.Left?.Right?.Right;
            if (newRight.Right != null)
            {
                newRight.Right.Parent = newRight;
            }

            node.Value = node.Left.Right.Value;
            node.Left = newLeft;
            node.Right = newRight;

            // Adjust height
            node.Height -= 1;
            node.Left.Height -= 1;
            node.Right.Height -= 2;
            MaintainHeightAfterInsert(node);
        }

        static void ModifyRL(AvlNode node)
        {
            // Adjust nodes
            var newLeft = CloneNode(node);
            newLeft.Parent = node;
            newLeft.Right = node.Right?.Left?.Left;
            if (newLeft.Left != null)
            {
                newLeft.Left.Parent = newLeft;
            }
            var newRight = CloneNode(node.Right);
            newRight.Parent = node;
            newRight.Left = node.Right?.Left?.Right;
            if (newRight.Right != null)
            {
                newRight.Right.Parent = newRight;
            }

            node.Value = node.Right.Left.Value;
            node.Left = newLeft;
            node.Right = newRight;

            // Adjust height
            node.Height -= 1;
            node.Left.Height -= 2;
            node.Right.Height -= 1;
            MaintainHeightAfterInsert(node);
        }

        static void Modify(AvlNode node)
        {
            if (Math.Abs(node.Parent?.Parent?.Factor ?? 0) < 2)
            {
                return;
            }

            if (node.IsLeftChild && node.Parent.IsLeftChild)
            {
                ModifyLL(node.Parent.Parent);
            }
            else if (node.IsRightChild && (node.Parent?.IsRightChild ?? false))
            {
                ModifyRR(node.Parent.Parent);
            }
            else if ((node?.Parent?.IsLeftChild ?? false) && node.IsRightChild)
            {
                ModifyLR(node.Parent.Parent);
            }
            else
            {
                ModifyRL(node.Parent.Parent);
            }

            Modify(node.Parent);
        }

        static void MaintainHeightAfterInsert(AvlNode node)
        {
            for (var i = node; i.Parent != null; i = i.Parent)
            {
                i.Parent.Height = Math.Max(i.Parent?.Left?.Height ?? 0, i.Parent?.Right?.Height ?? 0) + 1;
            }
        }

        static void Add(AvlNode node, int value, AvlNode parent = null)
        {
            var newNode = new AvlNode
            {
                Left = null,
                Right = null,
                Value = value,
                Parent = node
            };

            if (value >= node.Value)
            {
                if (node.Right == null)
                {
                    node.Right = newNode;
                    MaintainHeightAfterInsert(newNode);

                    if (Math.Abs(parent?.Factor ?? 0) > 1)
                    {
                        Modify(newNode);
                    }
                }
                else
                {
                    Add(node.Right, value, node);
                }
            }
            else
            {
                if (node.Left == null)
                {
                    node.Left = newNode;
                    MaintainHeightAfterInsert(newNode);

                    if (Math.Abs(parent?.Factor ?? 0) > 1)
                    {
                        Modify(newNode);
                    }
                }
                else
                {
                    Add(node.Left, value, node);
                }
            }
        }

        static AvlNode TestLL()
        {
            var root = new AvlNode { Value = 5 };
            Add(root, 4);
            Add(root, 3);
            Add(root, 2);
            Add(root, 1);
            return root;
        }

        static AvlNode TestRR()
        {
            var root = new AvlNode { Value = 1 };
            Add(root, 2);
            Add(root, 3);
            Add(root, 4);
            Add(root, 5);
            return root;
        }

        static AvlNode TestLR()
        {
            var root = new AvlNode { Value = 3 };
            Add(root, 1);
            Add(root, 2);
            return root;
        }

        static AvlNode TestRL()
        {
            var root = new AvlNode { Value = 1 };
            Add(root, 3);
            Add(root, 2);
            return root;
        }

        static AvlNode TestMixed()
        {
            var root = new AvlNode { Value = 10 };
            Add(root, 11);
            Add(root, 12);
            Add(root, 13);
            Add(root, 14);
            Add(root, 15);
            Add(root, 7);
            Add(root, 8);
            Add(root, 9);
            Add(root, 6);
            Add(root, 5);
            Add(root, 4);
            Add(root, 2);
            Add(root, 3);
            Add(root, 1);
            Add(root, 17);
            Add(root, 16);
            Add(root, 19);
            Add(root, 18);
            return root;
        }

        static void Main(string[] args)
        {
            var root1 = TestLL();
            var root2 = TestRR();
            var root3 = TestLR();
            var root4 = TestRL();
            var root5 = TestMixed();
            Console.Read();
        }
    }
}
