namespace SearchTree
{
    public class BitreeNode
    {
        public int Key { get; set; }

        public string Value { get; set; }

        public BitreeNode Left { get; set; }

        public BitreeNode Right { get; set; }
    }

    public class Map
    {
        private BitreeNode root;

        private BitreeNode Find(int key, BitreeNode n)
        {
            if (n == null)
                return null;
            if (n.Key == key)
                return n;
            if (n.Key < key)
                return Find(key, n.Right);
            else
                return Find(key, n.Left);
        }

        private void Insert(int key, string value, BitreeNode n)
        {
            if (n.Key < key)
            {
                if (n.Right == null)
                {
                    n.Right = new BitreeNode
                    {
                        Key = key,
                        Value = value
                    };
                }
                else
                {
                    Insert(key, value, n.Right);
                }
            }
            else
            {
                if (n.Left == null)
                {
                    n.Left = new BitreeNode
                    {
                        Key = key,
                        Value = value
                    };
                }
                else
                {
                    Insert(key, value, n.Left);
                }
            }
        }

        public string this[int key]
        {
            get
            {
                if (root == null)
                    return null;
                else
                    return Find(key, root).Value;
            }
            set
            {
                if (root == null)
                {
                    root = new BitreeNode
                    {
                        Key = key,
                        Value = value
                    };
                }
                else
                {
                    var node = Find(key, root);
                    if (node != null)
                    {
                        node.Value = value;
                    }
                    else
                    {
                        Insert(key, value, root);
                    }
                }
            }
        }
    }
}
