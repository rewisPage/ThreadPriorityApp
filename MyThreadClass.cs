namespace ThreadPriorityApp
{
    public class MyThreadClass
    {
        // Loops up to index 2 (runs 0, 1, 2) and sleeps for 0.5s (500 ms)
        public static void Thread1()
        {
            for (int loopCount = 0; loopCount <= 2; loopCount++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine("Name of Thread: " + thread.Name + " Process = " + loopCount);
                Thread.Sleep(500); // 0.5 seconds
            }
        }

        // Loops up to index 5 (runs 0 through 5) and sleeps for 1.5s (1500 ms)
        public static void Thread2()
        {
            for (int loopCount = 0; loopCount <= 5; loopCount++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine("Name of Thread: " + thread.Name + " Process = " + loopCount);
                Thread.Sleep(1500); // 1.5 seconds
            }
        }
    }
}