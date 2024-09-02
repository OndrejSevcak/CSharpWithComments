Random rnd = new Random();

//synchronous write from main UI thread
Console.WriteLine("This is a synchronous write");

// Creating tasks that execute asynchronously. 
// These tasks are not awaited here, so they start and run concurrently on different threads.
var main =  WriteToConsoleAsync(1);
var main2 = WriteToConsoleAsync(2);
var main3 = WriteToConsoleAsync(3);
var main4 = WriteToConsoleAsync(4);
var main5 = WriteToConsoleAsync(4);

var tasks = new List<Task> { main, main2, main3, main4, main5 };

// Another synchronous write from the main UI thread.
Console.WriteLine("This is a synchronous write");

// Awaiting the completion of all tasks. The Main method itself is asynchronous, 
// so the program will wait for all tasks to complete before exiting.
await Task.WhenAll(tasks);

// This method demonstrates asynchronous writing to the console.
// It simulates a random delay before writing, representing some asynchronous work.
async Task WriteToConsoleAsync(int taskNumber)
{
    // Task.Run is used to offload the work to a thread pool thread. 
    // The lambda function inside Task.Run simulates a delay and writes to the console.
    await Task.Run(() =>
    {
        var thread = Thread.CurrentThread;
        var delayMiliseconds = rnd.Next(500, 5000);

        // Task.Delay(delayMilliseconds).Wait() is a blocking call, which would run synchronously.
        // The whole lambda is already inside Task.Run, so it's running on a background thread.
        Task.Delay(delayMiliseconds).Wait();

        Console.WriteLine($"Writing to a console asynchronously from task {taskNumber} and Thread id: {thread.ManagedThreadId}");
    });
}


//The Console.WriteLine("This is a synchronous write"); statements execute synchronously,
//meaning they block the main thread until they complete.


//The WriteToConsoleAsync method is executed asynchronously.
//Although it involves blocking operations (Task.Delay(...).Wait()),
//it is offloaded to a thread pool thread using Task.Run, so it doesn't block the main thread.

//Each task runs on a separate thread from the thread pool, which is managed by the runtime.
//The Thread.CurrentThread.ManagedThreadId is used to identify which thread is executing the current task.