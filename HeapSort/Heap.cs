using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    public class Heap
    {
        private List<int> _data { get; set; } = new List<int>();
        public ICollection<int> Data => _data.AsReadOnly();

        public Heap()
        {

        }

        public Heap(IEnumerable<int> src)
        {
            _data = src.ToList();
            MinHeap();
        }

        public void Add(int num)
        {
            _data.Add(num);
            HeapFixup(_data.Count - 1);
        }

        public void Sort()
        {
            for (var i = _data.Count - 1; i >= 0; i--)
            {
                Swap(0, i);
                HeapFixdown(0, i);
            }
            _data.Reverse();
        }

        private void HeapFixup(int pos)
        {
            for (var i = pos.GetParent(); pos != 0 && i >= 0 && _data[i] > _data[pos]; pos = i, i = pos.GetParent())
                Swap(pos, i);
        }

        private void MinHeap()
        {
            for (var i = (_data.Count - 1) / 2; i >= 0; i--)
            {
                HeapFixdown(i, _data.Count());
            }
        }

        private void HeapFixdown(int pos, int actualCount)
        {
            var min_pos = pos;

            if (pos.GetLeftChild() < actualCount && _data[pos.GetLeftChild()] < _data[min_pos])
            {
                min_pos = pos.GetLeftChild();
            }

            if (pos.GetRightChild() < actualCount && _data[pos.GetRightChild()] < _data[min_pos])
            {
                min_pos = pos.GetRightChild();
            }

            if (pos == min_pos)
            {
                return;
            }

            Swap(pos, min_pos);
            HeapFixdown(min_pos, actualCount);
        }

        private void Swap(int pos1, int pos2)
        {
            var tmp = _data[pos1];
            _data[pos1] = _data[pos2];
            _data[pos2] = tmp;
        }
    }

    public static class Int32Extensions
    {
        public static int GetParent(this int self) => (self - 1) / 2;

        public static int GetLeftChild(this int self) => self * 2 + 1;

        public static int GetRightChild(this int self) => self * 2 + 2;
    }

}
