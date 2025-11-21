using System.Diagnostics;

namespace Multithreading.DivideAndConquer
{
    public interface IIntegerGenerator
    {
        int GenerateSync();
        int GenerateAsync();
        long SumGeneratedSync();
    }

    public class IntegerGenerator : IIntegerGenerator
    {
        private readonly List<int> integers = [];
        private readonly long amount = 0;

        public IntegerGenerator(long amount)
        {
            this.amount = amount;
        }

        public int GenerateSync()
        {
            var stopWatch = Stopwatch.StartNew();
            var random = new Random();

            integers.Clear();

            for (int i = 0; i < amount; i++)
            {
                integers.Add(random.Next(1, 100));
            }

            Console.WriteLine($"Generate Time: {stopWatch.ElapsedMilliseconds}");
            return integers.Count;
        }

        public int GenerateAsync()
        {
            var stopWatch = Stopwatch.StartNew();

            integers.Clear();

            var threads = new List<Thread>();
            var threadsAmount = Environment.ProcessorCount;
            var perThread = amount / threadsAmount;

            object _lock = new();

            for (int i = 0; i < threadsAmount; i++)
            {
                int threadIndex = i;

                var thread = new Thread(() =>
                {
                    var ints = new List<int>();

                    var start = perThread * threadIndex;
                    var end = perThread * (threadIndex + 1);

                    var random = new Random();

                    for (long y = start; y < end; y++)
                    {
                        ints.Add(random.Next(1, 100));
                    }

                    lock (_lock)
                    {
                        integers.AddRange(ints);
                    }
                });

                threads.Add(thread);
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
            
            Console.WriteLine($"Generate Time: {stopWatch.ElapsedMilliseconds}");
            return integers.Count;
        }

        public long SumGeneratedSync()
        {
            var stopWatch = Stopwatch.StartNew();
            long sum = 0;

            foreach (var i in integers)
            {
                sum += i;
            }

            Console.WriteLine($"SumGenerated Time: {stopWatch.ElapsedMilliseconds}");
            return sum;
        }

        public long SumGeneratedAsync()
        {
            var stopWatch = Stopwatch.StartNew();
            long sum = 0;

            var threads = new List<Thread>();
            var threadsAmount = Environment.ProcessorCount;
            var perThread = integers.Count / threadsAmount;

            var lockObject = new object();

            for (var i = 0; i < threadsAmount; i++)
            {
                var thread = new Thread(() =>
                {
                    var start = perThread * i;
                    var end = perThread * (i + 1);
                    var threadSum = 0;

                    for (int y = start; y < end; y++)
                    {
                        threadSum += integers[i];
                    }

                    lock (lockObject)
                    {
                        sum += threadSum;
                    }
                });

                threads.Add(thread);
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine($"SumGenerated Time: {stopWatch.ElapsedMilliseconds}");
            return sum;
        }
    }
}