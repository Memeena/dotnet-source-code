namespace AsyncTask{
    internal class Program{
        public static async Task Main(string[] args){
            Task firstTask = new Task(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine("Task 1");
            });
            ConsoleAfterDelay("Delay", 350);
            firstTask.Start();
            // await firstTask;
            Task secondTask = ConsoleAfterDelayAsync("Task 2", 250);
            Task thirdTask = ConsoleAfterDelayAsync("Task 3", 150);
            await secondTask;
            await thirdTask;

            Console.WriteLine("After the tasks are created");
        }

        static void ConsoleAfterDelay(string s,int delayTime){
            Thread.Sleep(delayTime);
            Console.WriteLine(s);

        }

        static async Task ConsoleAfterDelayAsync(string s,int delayTime){
            await Task.Delay(delayTime);
            Console.WriteLine($"{s} ms");
        }
    }
}
