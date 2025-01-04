// See https://aka.ms/new-console-template for more information

using AutoMapper;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;

namespace HelloWorld{


    internal class Program
    {
        public static void Main(string[] args)
        {

            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
            DataContextDapper dataContextDapper = new DataContextDapper(config);

            string computersJson = File.ReadAllText("ComputersSnake.json");
            // Mapper mapper= new Mapper(new MapperConfiguration(cfg=> cfg.CreateMap<ComputerSnake,Computer>().ForMember(destination=> destination.ComputerId,options=> options.MapFrom(source=>source.computer_id))));

//using Mapper package to map from snake case to model case
//             Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ComputerSnake, Computer>().ForMember(destination => destination.ComputerId, options => options.MapFrom(source => source.computer_id)).ForMember(destination=>destination.CPUCores,options=>options.MapFrom(source=>source.cpu_cores)).ForMember(destination=>destination.HasLTE,options=>options.MapFrom(source=>source.has_lte)).ForMember(destination=>destination.HasWifi,options=>options.MapFrom(source=>source.has_wifi)).ForMember(destination=>destination.ReleaseDate,options=>options.MapFrom(source=>source.release_date)).ForMember(destination=>destination.VideoCard,options=>options.MapFrom(source=>source.video_card)).ForMember(destination=>destination.Price,options=>options.MapFrom(source=>source.price))));

// IEnumerable<ComputerSnake>? computerSystem=System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computersJson);

// if(computerSystem != null){
//     IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computerSystem);
//     foreach(Computer computer in computerResult){
//                     Console.WriteLine(computer.Motherboard);
//     }
// }

//wihtout using mapper function to map the snake case to model case using the Json property name change in the model file
 IEnumerable<Computer>? computerSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson);
 if(computerSystem != null){
    foreach(Computer computer in computerSystem){
                    Console.WriteLine(computer.Motherboard);
    }
}
            // Console.WriteLine(computersJson);

            // JsonSerializerOptions options = new JsonSerializerOptions(){
            //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            // };

            // IEnumerable<Computer>? computers = JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson,options);

            // if(computers != null){
            //     foreach(Computer computer in computers){
            //         string sql = @$"INSERT INTO TutorialAppSchema.Computer (
            //             MotherBoard,CPUCores,HasWifi,HasLTE,ReleaseDate,Price,VideoCard) 
            //             VALUES ('{escapeSingleQuote( computer.Motherboard)}','{computer.CPUCores}' ,'{ computer.HasWifi}' ,'{computer.HasLTE}' ,'{computer.ReleaseDate?.ToString("yyyy-MM-dd")}' ,'{computer.Price.ToString("0.00", CultureInfo.InvariantCulture)}','{escapeSingleQuote(computer.VideoCard)}')";

            //         dataContextDapper.ExecuteSql(sql);

            //     }
            // }

            // }

            // static string escapeSingleQuote(string input){
            // string output = input.Replace("'","''");
            // return output;
            // }

            // DataContextEF entityFrameWork = new DataContextEF(config);

            // string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

            // IDbConnection dbConnection = new SqlConnection(connectionString);

            // string sqlCommand = "SELECT GETDATE()";
            // DateTime rightNow = dataContextDapper.LoadDataSingle<DateTime>(sqlCommand);

            // // // DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);

            // Console.WriteLine(rightNow.ToString());



            // Computer myComputer = new()
            //     {
            //         MotherBoard ="Z090",
            //         CPUCores = 2,
            //         HasWifi = false,
            //         HasLTE = false,
            //             ReleaseDate = DateTime.Now,
            //             Price = 1000.76m,
            //             VideoCard = "RTX 2060",
            //     };

            // entityFrameWork.Add(myComputer);
            // entityFrameWork.SaveChanges();

            // string sql = @$"INSERT INTO TutorialAppSchema.Computer (
            //             MotherBoard,CPUCores,HasWifi,HasLTE,ReleaseDate,Price,VideoCard) 
            //             VALUES ('{ myComputer.MotherBoard}','{myComputer.CPUCores}' ,'{ myComputer.HasWifi}' ,'{myComputer.HasLTE}' ,'{myComputer.ReleaseDate.ToString("yyyy-MM-dd")}' ,'{myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)}','{myComputer.VideoCard}')";

            // //                 Console.WriteLine(sql);

            //             int result = dataContextDapper.ExecuteSqlWithRowCount(sql) ;

            //             Console.WriteLine(result);
            // Console.WriteLine(myComputer.MotherBoard);
            // Console.WriteLine(myComputer.HasWifi);
            // Console.WriteLine(myComputer.VideoCard);
            //             string sqlSelect = @"SELECT 
            //             Computer.ComputerId
            //             Computer.MotherBoard,
            //             Computer.CPUCores,
            //             Computer.HasWifi,
            //             Computer.HasLTE,
            //             Computer.ReleaseDate,
            //             Computer.Price,
            //             Computer.VideoCard FROM TutorialAppSchema.Computer";

            //             //  IEnumerable<Computer> computers = dataContextDapper.LoadData<Computer>(sqlSelect);
            //             // foreach(Computer singleComputer in computers){
            //             //     Console.WriteLine($@"'{singleComputer.ComputerId}','{singleComputer.MotherBoard}','{singleComputer.HasWifi}','{singleComputer.HasLTE}','{singleComputer.ReleaseDate}','{singleComputer.Price}','{singleComputer.VideoCard}'");
            //             // }

            //              IEnumerable<Computer>? computersEF = entityFrameWork.Computer?.ToList<Computer>();
            // #pragma warning disable CS8602 // Dereference of a possibly null reference.
            //             foreach (Computer singleComputer in computersEF){
            //                 Console.WriteLine($@"'{singleComputer.ComputerId}','{singleComputer.MotherBoard}','{singleComputer.HasWifi}','{singleComputer.HasLTE}','{singleComputer.ReleaseDate}','{singleComputer.Price}','{singleComputer.VideoCard}'");
            //             }
            // #pragma warning restore CS8602 // Dereference of a possibly null reference.

        }
    }
    }

    
