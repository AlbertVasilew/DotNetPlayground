var cts = new CancellationTokenSource();

var thread = new Thread(() =>
{
    while (!cts.Token.IsCancellationRequested)
    {
        Console.WriteLine("Working...");
        Thread.Sleep(1000);
    }

    Console.WriteLine("Cancellation requested by user");
});

Console.WriteLine("Press C to cancel the operation");

thread.Start();

if (Console.ReadKey().Key == ConsoleKey.C)
    cts.Cancel();

thread.Join();
Console.WriteLine("Program finished");