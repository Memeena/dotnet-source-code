// See https://aka.ms/new-console-template for more information

using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Data;
using System.Globalization;

namespace HelloWorld{
    

    internal class Program{
        public static void Main(string[] args) {

            DataContextDapper dataContextDapper= new DataContextDapper();
            // string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

            // IDbConnection dbConnection = new SqlConnection(connectionString);

            string sqlCommand = "SELECT GETDATE()";
            DateTime rightNow = dataContextDapper.LoadDataSingle<DateTime>(sqlCommand);

            // // DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);

            Console.WriteLine(rightNow.ToString());

            

            Computer myComputer = new()
                {
                    MotherBoard ="Z075",
                    CPUCores = 3,
                    HasWifi = true,
                    HasLTE = false,
                        ReleaseDate = DateTime.Now,
                        Price = 950.76m,
                        VideoCard = "RTX 2060",
                };

            string sql = @$"INSERT INTO TutorialAppSchema.Computer (
                        MotherBoard,CPUCores,HasWifi,HasLTE,ReleaseDate,Price,VideoCard) 
                        VALUES ('{ myComputer.MotherBoard}','{myComputer.CPUCores}' ,'{ myComputer.HasWifi}' ,'{myComputer.HasLTE}' ,'{myComputer.ReleaseDate.ToString("yyyy-MM-dd")}' ,'{myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)}','{myComputer.VideoCard}')";

            //                 Console.WriteLine(sql);

                        int result = dataContextDapper.ExecuteSqlWithRowCount(sql) ;

                        Console.WriteLine(result);
            // Console.WriteLine(myComputer.MotherBoard);
            // Console.WriteLine(myComputer.HasWifi);
            // Console.WriteLine(myComputer.VideoCard);
            string sqlSelect = @"SELECT 
            Computer.MotherBoard,
            Computer.CPUCores,
            Computer.HasWifi,
            Computer.HasLTE,
            Computer.ReleaseDate,
            Computer.Price,
            Computer.VideoCard FROM TutorialAppSchema.Computer";

             IEnumerable<Computer> computers = dataContextDapper.LoadData<Computer>(sqlSelect);
            foreach(Computer singleComputer in computers){
                Console.WriteLine($@"'{singleComputer.MotherBoard}','{singleComputer.HasWifi}','{singleComputer.HasLTE}','{singleComputer.ReleaseDate}','{singleComputer.Price}','{singleComputer.VideoCard}'");
            }
        }
    }

    
}