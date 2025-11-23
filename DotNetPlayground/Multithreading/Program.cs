using Multithreading.Benefiting;

/* This PROJECT demonstrates primary benefits of multithreading:
1) Divide & Conquer
2) Offload long running tasks */

var syncGenerating = new IntegerGenerator(100000000);
var asyncGenerating = new IntegerGenerator(100000000);

var thread1 = new Thread(() =>
{
    var count = syncGenerating.GenerateSync();
    Console.WriteLine($"[SYNC] Integers: {count}");
    var sum = syncGenerating.SumGeneratedSync();
    Console.WriteLine($"[SYNC] Sum: {sum}");
});

thread1.Start();

var thread2 = new Thread(() =>
{
    var count = asyncGenerating.GenerateAsync();
    Console.WriteLine($"[ASYNC] Integers: {count}");
    var sum = asyncGenerating.SumGeneratedAsync();
    Console.WriteLine($"[ASYNC] Sum: {sum}");
});

thread2.Start();

Console.WriteLine("Main thread is not blocked");
Console.ReadLine();