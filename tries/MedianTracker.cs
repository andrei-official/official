using System;

namespace Official
{
    public class MedianTracker
    {
        public static void Run()
        {
            var medianTracker = new MedianTracker();
            var input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                medianTracker.Add(int.Parse(input));
                Console.WriteLine($"{medianTracker.Median:.0}");
                input = Console.ReadLine();
            }

            medianTracker.Unwind();
        }

        public MedianTracker()
        {
            BiggerThanMedian = new MinHeap();
            SmallerThanMedian = new MaxHeap();
        }

        private Heap BiggerThanMedian { get; }

        private Heap SmallerThanMedian { get; }

        public void Add(int value)
        {
            if (SmallerThanMedian.Size == 0 || SmallerThanMedian.Head > value)
            {
                SmallerThanMedian.Insert(value);
            }
            else
            {
                BiggerThanMedian.Insert(value);
            }

            while (SmallerThanMedian.Size > BiggerThanMedian.Size + 1)
            {
                BiggerThanMedian.Insert(SmallerThanMedian.RemoveHead());
            }
            
            while (BiggerThanMedian.Size > SmallerThanMedian.Size)
            {
                SmallerThanMedian.Insert(BiggerThanMedian.RemoveHead());
            }

            Console.WriteLine($"SmallerThanMedian={SmallerThanMedian.Size} | BiggerThanMedian={BiggerThanMedian.Size}");
        }

        public void Unwind()
        {
            while (SmallerThanMedian.Size > 0)
            {
                Console.Write($"S:{SmallerThanMedian.RemoveHead()}, ");
            }

            while (BiggerThanMedian.Size > 0)
            {
                Console.Write($"B:{BiggerThanMedian.RemoveHead()}, ");
            }
        }

        public double Median
        {
            get
            {
                if (SmallerThanMedian.Size == 0)
                {
                    throw new InvalidOperationException();
                }

                if (BiggerThanMedian.Size == 0)
                {
                    return SmallerThanMedian.Head;
                }

                if (BiggerThanMedian.Size == SmallerThanMedian.Size)
                {
                    var result =(BiggerThanMedian.Head + SmallerThanMedian.Head) / 2d; 
                    Console.WriteLine($"({BiggerThanMedian.Head} + {SmallerThanMedian.Head}) / 2d = {result}");
                    return result;
                }

                return SmallerThanMedian.Head;
            }
        }
    }
}