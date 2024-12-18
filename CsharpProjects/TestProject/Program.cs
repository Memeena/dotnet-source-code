// // using CSharpFundamentals.Math;
// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using CSharpFundamentals.Math;
using LibraryManagement;

// namespace CSharpFundamentals
// {
// //     public enum ShippingMethod{
// //         RegularAirMail = 1,
// //         RegisteredAirMail =2,
// //         Express = 3,

// //     }
// //        public class Person
// //     {
// //         public string firstName = "";
// //         public string lastName = "";
// //         public void Introduce()
// //         {
// //             Console.WriteLine("My name is " + firstName + " " + lastName);
// //         }
// //     }
//        class Program {
//         public static void Main(string[] args){
// //             Person meena = new Person();
//             Calculator calculator= new Calculator();    
// //             meena.firstName = "Meena";
// //             meena.lastName = "Krishna"; 
// //             meena.Introduce();
//             var result = calculator.Add(1, 2);
//             Console.WriteLine(result);
// //             string name = string.Format("{0} {1}", meena.firstName, meena.lastName);
// //             Console.WriteLine("name:" + name);
// //             var numbers = new int[3] {1,2,3};
// //             string list = string.Join(" ", numbers);
// //             Console.WriteLine("list:" + list);
// //             var methodId = 2;
// //             Console.WriteLine((ShippingMethod)methodId);
// //             Console.WriteLine((int)ShippingMethod.RegularAirMail);
// //             var methodName = "Express";
// //             var shippingMethod = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), methodName);
// //             Console.WriteLine(shippingMethod);
// //             var array1 = new int[3] { 1, 2, 3 };
// //             var array2 = array1;
// //             array2[0] = 0;
// //             Console.WriteLine(array2);

//         }
//     }
// // class Program{
//         // public static void Main(string[] args)
//         // {
//             //Arrays length,IndexOf,Clear,Sort,Reverse
//             // var random = new Random();
//             // const int passowrdLength = 10;
//             //     var buffer = new char[passowrdLength];

//             //Random class

//             // for(int i = 0; i < passowrdLength;i++){
//             //     buffer[i] = (char)('a'+random.Next(0,26));
//             // }

//             // var password = new string(buffer);
//             // Console.WriteLine(password);  

//             //List

//             // var numbers = new List<int>() { 1, 2, 3, 4 };
//             // numbers.Add(50);

//             // foreach (int i in numbers)
//             // {
//             //     Console.WriteLine(i);
//             // }
//             // Console.WriteLine(numbers.IndexOf(50));


//             // var characters = new List<char>() { 'a', 'b' };

//             // characters.AddRange(new char[] { 'c', 'd','b' });

//             // foreach (var item in characters)
//             // {
//             //     Console.WriteLine(item);
//             // }

//             // Console.WriteLine(characters.IndexOf('b'));
//             // Console.WriteLine(characters.Remove('b'));
//             // Console.WriteLine(characters.IndexOf('b'));

//             //             Exercise 1- When you post a message on Facebook, depending on the number of people who like your post, Facebook displays different information.

//             // If no one likes your post, it doesn't display anything.
//             // If only one person likes your post, it displays: [Friend's Name] likes your post.
//             // If two people like your post, it displays: [Friend 1] and [Friend 2] like your post.
//             // If more than two people like your post, it displays: [Friend 1], [Friend 2] and [Number of Other People] others like your post.
//             // Write a program and continuously ask the user to enter different names, until the user presses Enter (without supplying a name). Depending on the number of names provided, display a message based on the above pattern.
//             /*
//                         List<string> names = new List<string>();
//             while(true){

//                         Console.WriteLine("Type your name:");
//                        var name= Console.ReadLine();

//                        if(String.IsNullOrEmpty(name)){
//                         break;
//                        }else{
//                         // var names = new List<string>() { };
//                         names.Add(name);
//                         Console.WriteLine("Count:" + names.Count);
//                         foreach(string s in names){
//                             Console.WriteLine(s);   
//                         }

//                         if(names.Count == 1){
//                             Console.WriteLine("{0} likes your post",names[0]);
//                         }else if(names.Count == 2){
//                             Console.WriteLine("{0} and {1} likes your post",names[0],names[1]);
//                         }else{
//                             Console.WriteLine("{0},{1} and {2} others like your post",names[0],names[1],names.Count-2);
//                         }
//                        }
//                     }

//                        */

//             /*
//             Exercise 2- Write a program and ask the user to enter their name. Use an array to reverse the name and then store the result in a new string. Display the reversed name on the console.*/
//             /*

//                         Console.WriteLine("Enter your name:");
//                         var inputString = Console.ReadLine();

//                             char[] charArray = inputString.ToCharArray();

//                             Array.Reverse(charArray);

//                             Console.WriteLine(string.Join("", charArray));
//             */
//             /*Exercise 3- Write a program and ask the user to enter 5 numbers. If a number has been previously entered, display an error message and ask the user to re-try. Once the user successfully enters 5 unique numbers, sort them and display the result on the console.*/
//             /******************************************************************************
//             Console.WriteLine("Enter 5 numbers!");
//                         int[] input = new int[5];
//                         int inputCount =0;
//             for(int i=0; inputCount <5 ;){
//                 Console.WriteLine("@Enter number:");
//                 int inputNum =int.Parse(Console.ReadLine());

//                             if (Array.IndexOf(input, inputNum) == -1)
//                             {
//                                 input[i] = inputNum;
//                                 inputCount++;
//                                 i++ ;
//                             }else{
//                                 Console.WriteLine("Re-try!");
//                             }
//             }
//             Array.Sort(input);
//             foreach(int i in input){
//                 Console.Write(i + " ");
//             }*/

//             /******************************************************************************
//             Exercise 4- Write a program and ask the user to continuously enter a number or type "Quit" to exit. The list of numbers may include duplicates. Display the unique numbers that the user has entered.*/
//             /*
//             var endOfLoop = false;
//     List<int> numbers = new List<int>();
// while(!endOfLoop){
//     Console.WriteLine("Enter a number:");
//     var input = Console.ReadLine();
//                 if (input == "Quit")
//                 {
//                     endOfLoop = true;
//                 }
//                 else
//                 {
//                     numbers.Add(int.Parse(input));
//                 }
// }
// List<int> uniqueList = numbers.Distinct().ToList();
// foreach(int number in uniqueList){
//     Console.WriteLine(number+" ");
// }*/
//             // Date and Time
//             // var dateTime = new DateTime(2024, 1, 1);
//             // var yesterday = dateTime.AddDays(-1);
//             // Console.WriteLine("{0} {1}", yesterday, dateTime.Hour);
// // DateTime time = DateTime.Now;
// //             Console.WriteLine("" + time.ToString("yyyy-MM-dd h:mm:ss tt"));
// //             Console.WriteLine("" + time.ToShortTimeString());
// //             Console.WriteLine("" + time.ToLongTimeString());
// //             Console.WriteLine("" + time.ToLongDateString());
// //             Console.WriteLine("" + time.ToShortDateString());
// //Debugging techniques provided by visual studio community version - Breakpoints,Stepping,inspecting variables,memory inspection,Call stack inspection,watch expressions
// //Strings - ToLower,ToUpper,Trim,IndexOf,LastIndexOf,Substring(startIndex),Substring(startIndex,length),Replace,string.IsNullOrEmpty,string.IsNullOrWhiteSpace,str.Split
// //Converting string to number -> int.Parse or Convert.ToInt32(str)
// //Converting number to string -> i.ToString()
//         }
    
    namespace Properties{
        internal class Program{
            static void Main(string[] args) {
            // Person person = new Person();
            // person.Name = "Meenakshi";
            // person.DisplayInfo();
            Console.Write("Enter the library name:");
            string libraryName = Console.ReadLine();

            Console.Write("Enter the maximum books the library can hold:");
            int maxBooks = int.Parse(Console.ReadLine());

            Library myLibrary = new Library(libraryName,maxBooks);

            do
            {
        Console.Write("\nEnter the book titles:");
                string input = Console.ReadLine();
                myLibrary.AddBooks(input);
                maxBooks--;
            } while (maxBooks >= 0);

myLibrary.DisplayBooks();
            }
        }
    }