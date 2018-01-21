using System;

namespace Official
{
    public class MinHeap : Heap
    {
        public int Min => Values[0];

        protected override void HeapifyUp(int size)
        {
            var current = size - 1;
            while (HasParent(current) && GetParent(current) > Values[current])
            {
                Swap(current, GetParentIndex(current));
                current = GetParentIndex(current);
            }
        }

        protected override void HeapifyDown()
        {
            var current = 0;
            while (HasLeftChild(current))
            {
                var smallerChildIndex = GetLeftChildIndex(current);
                if (HasRightChild(current) && GetRightChild(current) < GetLeftChild(current))
                {
                    smallerChildIndex = GetRightChildIndex(current);
                }

                if (Values[current] < Values[smallerChildIndex])
                {
                    return;
                }

                Swap(current, smallerChildIndex);
                current = smallerChildIndex;
            }
        }
    }
}