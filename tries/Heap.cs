using System;

namespace Official
{
    public abstract class Heap
    {
        protected Heap()
        {
            Values = new int[32];
        }

        public int Size { get; private set; }
        protected int[] Values { get; private set; }

        public int Head => Values[0];

        public int RemoveHead()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }

            var head = Values[0];
            Values[0] = Values[Size - 1];
            Size--;
            HeapifyDown();
            return head;
        }

        public void Insert(int value)
        {
            EnsureCapacity();
            Values[Size++] = value;
            HeapifyUp(Size);
        }

        protected abstract void HeapifyUp(int size);
        protected abstract void HeapifyDown();

        private void EnsureCapacity()
        {
            if (Size == Values.Length - 1)
            {
                var resized = new int[Values.Length * 2];
                Array.Copy(Values, resized, Values.Length);
                Values = resized;
            }
        }

        protected void Swap(int a, int b)
        {
            if (Values[a] == Values[b]) return;
            Values[a] ^= Values[b];
            Values[b] ^= Values[a];
            Values[a] ^= Values[b];
        }

        protected int GetParentIndex(int index) => (index - 1) / 2;
        protected int GetLeftChildIndex(int index) => index * 2 + 1;
        protected int GetRightChildIndex(int index) => index * 2 + 2;

        protected bool HasParent(int index) => index > 0;
        protected bool HasLeftChild(int index) => GetLeftChildIndex(index) < Size;
        protected bool HasRightChild(int index) => GetRightChildIndex(index) < Size;

        protected int GetParent(int index) => Values[GetParentIndex(index)];
        protected int GetLeftChild(int index) => Values[GetLeftChildIndex(index)];
        protected int GetRightChild(int index) => Values[GetRightChildIndex(index)];
    }
}