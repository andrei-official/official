namespace Official
{
    public class MaxHeap : Heap
    {
        protected override void HeapifyUp(int size)
        {
            var current = size - 1;
            while (HasParent(current) && GetParent(current) < Values[current])
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
                var biggestChildIndex = GetLeftChildIndex(current);
                if (HasRightChild(current) && GetRightChild(current) > GetLeftChild(current))
                {
                    biggestChildIndex = GetRightChildIndex(current);
                }

                if (Values[biggestChildIndex] < Values[current])
                {
                    return;
                }

                Swap(biggestChildIndex, current);
                current = biggestChildIndex;
            }
        }
    }
}