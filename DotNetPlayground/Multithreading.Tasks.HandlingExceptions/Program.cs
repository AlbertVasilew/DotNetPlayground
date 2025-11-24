var tasks = new List<Task>
{
    Task.Run(() =>
    {
        throw new InvalidOperationException();
    }),
    Task.Run(() =>
    {
        throw new ArgumentException();
    })
};

// This will not break the execution and will show exceptions only if
// we log them as below:
// P.S: if we add await it will act as WaitAll

Task.WhenAll(tasks).ContinueWith(t =>
{
    if (t.Exception != null)
    {
        foreach (var exception in t.Exception.InnerExceptions)
        {
            Console.WriteLine(exception);
        }
    }
});

// This will break the execution and will throw exceptions in main thread
// because no way to continue execution due to exceptions

//Task.WaitAll(tasks.ToArray());

Console.WriteLine("End Of Program");
Console.ReadLine();