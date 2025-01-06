namespace AsyncTask{
    internal class Program{
        public static async Task Main(string[] args){
            Task firstTask = new Task(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine("First Task");
            });
            // firstTask.Start();
            await firstTask;

            Console.WriteLine("After the first task");
        }
    }
}
