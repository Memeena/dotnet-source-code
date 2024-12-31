// See https://aka.ms/new-console-template for more information

using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Data;
using System.Globalization;

namespace HelloWorld{
    

    internal class Program{
        public static void Main(string[] args) {

            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
            DataContextDapper dataContextDapper= new DataContextDapper(config);
            DataContextEF entityFrameWork = new DataContextEF(config);

            // string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

            // IDbConnection dbConnection = new SqlConnection(connectionString);

            string sqlCommand = "SELECT GETDATE()";
            DateTime rightNow = dataContextDapper.LoadDataSingle<DateTime>(sqlCommand);

            // // DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);

            Console.WriteLine(rightNow.ToString());

            

            Computer myComputer = new()
                {
                    MotherBoard ="Z090",
                    CPUCores = 2,
                    HasWifi = false,
                    HasLTE = false,
                        ReleaseDate = DateTime.Now,
                        Price = 1000.76m,
                        VideoCard = "RTX 2060",
                };

            entityFrameWork.Add(myComputer);
            entityFrameWork.SaveChanges();

            // string sql = @$"INSERT INTO TutorialAppSchema.Computer (
            //             MotherBoard,CPUCores,HasWifi,HasLTE,ReleaseDate,Price,VideoCard) 
            //             VALUES ('{ myComputer.MotherBoard}','{myComputer.CPUCores}' ,'{ myComputer.HasWifi}' ,'{myComputer.HasLTE}' ,'{myComputer.ReleaseDate.ToString("yyyy-MM-dd")}' ,'{myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)}','{myComputer.VideoCard}')";

            // //                 Console.WriteLine(sql);

            //             int result = dataContextDapper.ExecuteSqlWithRowCount(sql) ;

            //             Console.WriteLine(result);
            // Console.WriteLine(myComputer.MotherBoard);
            // Console.WriteLine(myComputer.HasWifi);
            // Console.WriteLine(myComputer.VideoCard);
            string sqlSelect = @"SELECT 
            Computer.ComputerId
            Computer.MotherBoard,
            Computer.CPUCores,
            Computer.HasWifi,
            Computer.HasLTE,
            Computer.ReleaseDate,
            Computer.Price,
            Computer.VideoCard FROM TutorialAppSchema.Computer";

            //  IEnumerable<Computer> computers = dataContextDapper.LoadData<Computer>(sqlSelect);
            // foreach(Computer singleComputer in computers){
            //     Console.WriteLine($@"'{singleComputer.ComputerId}','{singleComputer.MotherBoard}','{singleComputer.HasWifi}','{singleComputer.HasLTE}','{singleComputer.ReleaseDate}','{singleComputer.Price}','{singleComputer.VideoCard}'");
            // }

             IEnumerable<Computer>? computersEF = entityFrameWork.Computer?.ToList<Computer>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (Computer singleComputer in computersEF){
                Console.WriteLine($@"'{singleComputer.ComputerId}','{singleComputer.MotherBoard}','{singleComputer.HasWifi}','{singleComputer.HasLTE}','{singleComputer.ReleaseDate}','{singleComputer.Price}','{singleComputer.VideoCard}'");
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        }
    }

    
}