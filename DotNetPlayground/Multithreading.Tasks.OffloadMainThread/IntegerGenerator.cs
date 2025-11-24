namespace Multithreading.Tasks.OffloadMainThread
{
    public class IntegerGenerator
    {
        private readonly int amount;
        private readonly int[] ints;

        public IntegerGenerator(int amount)
        {
            this.amount = amount;
            ints = new int[amount];
        }

        public void Generate()
        {
            var random = new Random();

            for (int i = 0; i < amount; i++)
            {
                ints[i] = random.Next(1, 100);
            }
        }

        public void SumAsync()
        {
            var processorCount = Environment.ProcessorCount;
            var segmentSize = amount / processorCount;
            var tasks = new List<Task<int>>();

            for (int i = 0; i < processorCount; i++)
            {
                var start = i * segmentSize;
                var end = (i == processorCount - 1) ? ints.Length : start + segmentSize;

                var task = Task.Run(() =>
                {
                    int sum = 0;
                    for (int j = start; j < end; j++)
                    {
                        sum += ints[j];
                    }
                    return sum;
                });

                tasks.Add(task);
            }

            // This achieves non blocking of main thread
            Task.WhenAll(tasks).ContinueWith(t =>
            {
                Console.WriteLine($"[Main Thread Offload (Not Blocking)] Sum is: {t.Result.Sum()}");
            });

            // While this will block main thread:
            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"[Main Thread Blocking] Sum is: {tasks.Select(x => x.Result).Sum()}");
        }
    }
}