using Multithreading.DivideAndConquer;
using System.Diagnostics;

var syncGenerating = new IntegerGenerator(1000000000);
var asyncGenerating = new IntegerGenerator(1000000000);

var stopwatch = Stopwatch.StartNew();

var syncTask = Task.Run(() =>
{
    var count = syncGenerating.GenerateSync();
    Console.WriteLine($"[SYNC] Integers: {count}");
    var sum = syncGenerating.SumGeneratedSync();
    Console.WriteLine($"[SYNC] Sum: {sum}");
});

var asyncTask = Task.Run(async () =>
{
    var count = asyncGenerating.GenerateAsync();
    Console.WriteLine($"[ASYNC] Integers: {count}");
    var sum = asyncGenerating.SumGeneratedAsync();
    Console.WriteLine($"[ASYNC] Sum: {sum}");
});

await Task.WhenAll(syncTask, asyncTask);

Console.WriteLine("Both generations completed in parallel (offload long running tasks)");
Console.WriteLine($"Estimation Time: {stopwatch.ElapsedMilliseconds}");