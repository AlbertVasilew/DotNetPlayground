var usersLock = new object();
var ordersLock = new object();

var thread = new Thread(ManageUsers);
thread.Start();

ManageOrders();

thread.Join();

void ManageUsers()
{

    lock (usersLock)
    {
        Console.WriteLine("Users management acquired");

        lock (ordersLock)
        {
            Console.WriteLine("Orders management acquired");
        }
    }
}

void ManageOrders()
{
    lock (ordersLock)
    {
        Console.WriteLine("Orders management acquired");

        lock (usersLock)
        {
            Console.WriteLine("Users management acquired");
        }
    }
}

Console.WriteLine("Application finished");