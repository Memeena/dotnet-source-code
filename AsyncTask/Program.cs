namespace AsyncTask{
    internal class Program{
        public static void Main(string[] args){
            Task firstTask = new Task(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine("First Task");
            });

            Console.WriteLine("After the first task");
        }
    }
}
