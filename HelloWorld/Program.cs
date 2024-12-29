// See https://aka.ms/new-console-template for more information

using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Globalization;

namespace HelloWorld{
    

    internal class Program{
        public static void Main(string[] args) {
            string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

            IDbConnection dbConnection = new SqlConnection(connectionString);

            string sqlCommand = "SELECT GETDATE()";

            DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);

            Console.WriteLine(rightNow.ToString());

            

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

string sql = @$"INSERT INTO TutorialAppSchema.Computer (
            MotherBoard,CPUCores,HasWifi,HasLTE,ReleaseDate,Price,VideoCard) 
            VALUES ('{ myComputer.MotherBoard}','{myComputer.CPUCores}' ,'{ myComputer.HasWifi}' ,'{myComputer.HasLTE}' ,'{myComputer.ReleaseDate.ToString("yyyy-MM-dd")}' ,'{myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)}','{myComputer.VideoCard}')";

                Console.WriteLine(sql);

            int result = dbConnection.Execute(sql);

            Console.WriteLine(result);
            // Console.WriteLine(myComputer.MotherBoard);
            // Console.WriteLine(myComputer.HasWifi);
            // Console.WriteLine(myComputer.VideoCard);
        }
    }
}