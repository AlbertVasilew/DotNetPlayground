using Multithreading.Tasks.OffloadMainThread;

var generator = new IntegerGenerator(5000000);
generator.Generate();
generator.SumAsync();

Console.WriteLine("End of program");
Console.ReadLine();