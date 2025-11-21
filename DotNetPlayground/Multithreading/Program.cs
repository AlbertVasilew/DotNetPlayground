using Multithreading.DivideAndConquer;

// [SYNC] is using only 1 thread (main)

var syncGenerating = new IntegerGenerator(1000000000);

Console.WriteLine("[SYNC]");
Console.WriteLine($"Generated Integers: {syncGenerating.GenerateSync()}");
Console.WriteLine($"Sum Generated: {syncGenerating.SumGeneratedSync()}");

Console.WriteLine("----------");

// [ASYNC] is using as many threads as the processor cores are

var asyncGenerating = new IntegerGenerator(1000000000);

Console.WriteLine("[ASYNC]");
Console.WriteLine($"Generated Integers [SYNC]: {asyncGenerating.GenerateAsync()}");
Console.WriteLine($"Sum Generated [SYNC]: {asyncGenerating.SumGeneratedAsync()}");