using System;
using System.Collections.Generic;

namespace BinaryTreeWithLevelPointer
{
    class Tree
    {
        public Node Root { get; set; }

        public List<Node> LevelHead { get; set; }

        // 构建层序指针
        public void InitLevelHead()
        {
            LevelHead = new List<Node>();
            var i = 1;
            LevelHead.Add(Root);
            while (i - 1 < LevelHead.Count && LevelHead[i - 1] != null)
            {
                var lastLevellastNode = LevelHead[i - 1];
                Node currentLevelLastNode = null;
                do
                {
                    if (lastLevellastNode.Left != null)
                    {
                        if (currentLevelLastNode == null)
                        {
                            LevelHead.Add(lastLevellastNode.Left);
                            currentLevelLastNode = lastLevellastNode.Left;
                        }
                        else
                        {
                            currentLevelLastNode.Next = lastLevellastNode.Left;
                            currentLevelLastNode = currentLevelLastNode.Next;
                        }
                    }
                    if (lastLevellastNode.Right != null)
                    {
                        if (currentLevelLastNode == null)
                        {
                            LevelHead.Add(lastLevellastNode.Right);
                            currentLevelLastNode = lastLevellastNode.Right;
                        }
                        else
                        {
                            currentLevelLastNode.Next = lastLevellastNode.Right;
                            currentLevelLastNode = currentLevelLastNode.Next;
                        }
                    }

                    if (lastLevellastNode.Next == null)
                    {
                        if (i < LevelHead.Count)
                            lastLevellastNode.Next = LevelHead[i];
                        break;
                    }

                    lastLevellastNode = lastLevellastNode.Next;
                }
                while (lastLevellastNode != null);
                ++i;
            }
        }

        // 层序遍历
        public IEnumerable<int> LevelTraversal()
        {
            var x = Root;
            do
            {
                yield return x.Value;
                x = x.Next;
            }
            while (x != null);
        }

        // 找到插入的孩子的在层序中的前驱节点，并返回前驱是否在上一层，并返回孩子节点所在层数
        private Tuple<Node, bool, int> FindTargetNode(Node n, bool IsLeft = true)
        {
            var node = n;
            Node targetNextNode = null, currentLevelLastNode = null;
            int currentLevel;

            // 寻找添加的孩子在层序中的后继节点以及缓存当前层最后一个节点并推算当前层数
            do
            {
                if (targetNextNode == null)
                {
                    if (node.Left != null)
                        targetNextNode = node.Left;
                    else if (node.Right != null)
                        targetNextNode = node.Right;
                }
                if (LevelHead.Contains(node.Next) || node.Next == null)
                {
                    if (node.Next == null)
                        currentLevel = LevelHead.Count - 1;
                    else
                        currentLevel = LevelHead.IndexOf(node.Next) - 1;
                    currentLevelLastNode = node;
                    break;
                }
                node = node.Next;
            }
            while (true);

            // 从当前层开始遍历，遍历至当前节点结束（不含）
            node = LevelHead[currentLevel];
            Node target = null;
            while (node != n)
            {
                if (node.Left != null)
                    target = node.Left;
                if (node.Right != null)
                    target = node.Right;
                node = node.Next;
            }
            if (n.Left != null & !IsLeft)
                target = n.Left;
            return target == null ? new Tuple<Node, bool, int>(currentLevelLastNode, true, currentLevel + 1) : new Tuple<Node, bool, int>(target, false, -1);
        }

        // 向指定节点添加左孩子
        public void AppendLeft(Node n, int value)
        {
            if (n.Left != null)
                throw new InvalidOperationException();
            n.Left = new Node { Value = value };

            // 寻找孩子在层序中的前驱并调整Next指针
            var result = FindTargetNode(n, true);
            n.Left.Next = result.Item1.Next;
            result.Item1.Next = n.Left;

            // 调整LevelHead
            if (result.Item2)
            {
                LevelHead[result.Item3] = n.Left;
            }
        }

        // 向指定节点添加右孩子
        public void AppendRight(Node n, int value)
        {
            if (n.Right != null)
                throw new InvalidOperationException();
            n.Right = new Node { Value = value };

            // 寻找孩子在层序中的前驱并调整Next指针
            var result = FindTargetNode(n, false);
            n.Right.Next = result.Item1.Next;
            result.Item1.Next = n.Right;

            // 调整LevelHead
            if (result.Item2)
            {
                LevelHead[result.Item3] = n.Right;
            }
        }
    }

    class Node
    {
        public int Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node Next { get; set; }
    }

    class Program
    {
        // 构建一棵树
        static Tree Arrange()
        {
            var tree = new Tree();
            tree.Root = new Node
            {
                Value = 3,
                Left = new Node
                {
                    Value = 7,
                    Left = new Node { Value = 5 },
                    Right = new Node
                    {
                        Value = 4,
                        Left = new Node { Value = 25 },
                        Right = new Node
                        {
                            Value = 6,
                            Left = new Node { Value = 5 }
                        }
                    }
                },
                Right = new Node
                {
                    Value = 9,
                    Left = new Node
                    {
                        Value = 10,
                        Right = new Node
                        {
                            Value = 13,
                            Left = new Node { Value = 20 },
                            Right = new Node { Value = 7 }
                        }
                    }
                }
            };
            return tree;
        }

        static void Main(string[] args)
        {
            var tree = Arrange();
            tree.InitLevelHead();
            tree.AppendRight(tree.Root.Left.Right.Left, 1);
            tree.AppendRight(tree.Root.Left.Right.Right, 2);
            foreach (var x in tree.LevelTraversal())
            {
                Console.Write(x + " ");
            }
            Console.Read();
        }
    }
}
