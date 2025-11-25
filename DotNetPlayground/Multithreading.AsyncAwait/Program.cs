AsynchronousMethod();

Console.WriteLine($"End of program. Thread: {Thread.CurrentThread.ManagedThreadId}");
Console.ReadLine();

async void AsynchronousMethod()
{
    Console.WriteLine($"Start of AsynchronousMethod() call. Thread: {Thread.CurrentThread.ManagedThreadId}");

    await ApiCall(); // here the calling thread is released. If no await, it will wait
    Thread.Sleep(2000);

    Console.WriteLine($"End of AsynchronousMethod() call. Thread: {Thread.CurrentThread.ManagedThreadId}");
}

async Task ApiCall()
{
    await Task.Run(() =>
    {
        Console.WriteLine($"Calling API ... Thread: {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(2000);
        Console.WriteLine($"API call finished. Thread: {Thread.CurrentThread.ManagedThreadId}");
    });
}