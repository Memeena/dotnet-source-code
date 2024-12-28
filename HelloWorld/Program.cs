// See https://aka.ms/new-console-template for more information

using HelloWorld.Models;
using System;

namespace HelloWorld{
    

    internal class Program{
        public static void Main(string[] args) {
            Computer myComputer = new()
                {
                    MotherBoard ="Z076",
                    CPUCores = 3,
                    HasWifi = true,
                    HasLTE = false,
                        ReleaseDate = DateTime.Now,
                        Price = 943.76m,
                        VideoCard = "RTX 2060",
                };

            Console.WriteLine(myComputer.MotherBoard);
            Console.WriteLine(myComputer.HasWifi);
            Console.WriteLine(myComputer.VideoCard);
        }
    }
}